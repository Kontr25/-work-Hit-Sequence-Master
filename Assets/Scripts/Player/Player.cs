using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerObj;
    [SerializeField] private ChooserEnemies _chooserEnemies;
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Rigidbody[] _deathRigidbody;
    [SerializeField] private PlayerAnimation _animator;
    [SerializeField] private ParticleSystem _manTrail;
    private bool _death;
    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            if(enemy.IsTarget() == true)
            {
                _enemy = enemy;
                _animator.Attack();
                Invoke(nameof(StopPlayTrail), 0.2f);
            }
        }
    }

    private void StopPlayTrail()
    {
        _manTrail.Stop();
    }

    public void EnemyDeath(int g)
    {
        _enemy.Death(g);
    }

    public void Death(int i)
    {
        _death = true;
        _chooserEnemies.AgentDisable();
        _playerCollider.enabled = false;
        _playerObj[2].SetActive(false);
        _playerObj[i].SetActive(true);
    }

    public bool IsDeath()
    {
        return _death;
    }
}
