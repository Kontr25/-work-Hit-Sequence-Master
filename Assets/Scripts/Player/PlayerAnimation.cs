using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem[] _particle;
    [SerializeField] private Player _payer;
    [SerializeField] private CinemachineShake _shakeLeft;
    [SerializeField] private CinemachineShake _shakeRight;
    [SerializeField] private ParticleSystem _wave;
    [SerializeField] private GameObject _waveTrigger;
    private int _score;

    public void Attack()
    {
        if (_score == 0)
        {
            _animator.SetTrigger("Attack0");
            _score++;
        }
        else if (_score == 1)
        {
            _animator.SetTrigger("Attack1");
            _score++;
        }
        else if (_score == 2)
        {
            _animator.SetTrigger("Attack2");
            _score++;
        }
        else if (_score == 3)
        {
            _animator.SetTrigger("Attack3");
            _score++;
        }
        else if (_score == 4)
        {
            _animator.SetTrigger("Attack4");
            _score = 0;
        }
    }


    public void ParticlePlay()
    {
        for (int i = 0; i < _particle.Length; i++)
        {

            _particle[i].Play();
        }
    }

    public void ParticlePause()
    {
        for (int i = 0; i < _particle.Length; i++)
        {
            _particle[i].Stop();
            AnimationSpeed(0.08f);
        }
    }

    public void AnimationSpeed(float i)
    {
        _animator.speed = i;
    }

    public void EnemyDeath()
    {
        Instantiate(_waveTrigger, transform.position, transform.rotation, transform);
        _wave.Play();
        if (_score - 1 == 0) _payer.EnemyDeath(0);
        else if (_score - 1 == 1 || _score -1 == 3) _payer.EnemyDeath(1);
        else if (_score - 1 == 2) _payer.EnemyDeath(2);
        else if (_score - 1 == -1) _payer.EnemyDeath(3);
    }

    public void ShakeCamera()
    {
        _shakeLeft.ShakeCamera(5f, 0.2f);
        _shakeRight.ShakeCamera(5f, 0.2f);
    }
}
