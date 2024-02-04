using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem[] _slashParticle;
    private Player _player;
    private int _score;

    private void Start()
    {
        _score = Random.Range(0, 3);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void Attack()
    {
        Debug.Log(_score);
        if (_score == 0)
        {
            _animator.SetTrigger("Attack0");
        }
        else if (_score == 1)
        {
            _animator.SetTrigger("Attack1");
        }
        else if (_score == 2)
        {
            _animator.SetTrigger("Attack2");
        }
        else if (_score == 3)
        {
            _animator.SetTrigger("Attack3");
        }
    }


    public void ParticlePlay()
    {
        for (int i = 0; i < _slashParticle.Length; i++)
        {

            _slashParticle[i].Play();
        }
    }

    public void ParticlePause()
    {
        AnimationSpeed(0.08f);
        for (int i = 0; i < _slashParticle.Length; i++)
        {
            _slashParticle[i].Stop();
        }
    }

    public void AnimationSpeed(float i)
    {
        _animator.speed = i;
    }

    public void PlayerDeath()
    {
        if (_score - 1 == 0 || _score - 1 == 2) _player.Death(0);
        else if (_score - 1 == -1 || _score - 1 == 1) _player.Death(1);
    }

    public void GetDamage()
    {
        _animator.SetTrigger("Damage");
    }

    public void SlowAnimation()
    {
        AnimationSpeed(0.005f);
    }
}
