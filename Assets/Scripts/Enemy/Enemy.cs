using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemy;
    [SerializeField] private Collider _enemyCollider;
    private bool _isTargetForPlayer;
    private Player _player;
    [SerializeField] private GameObject[] _enemyObj; 
    [SerializeField] private CinemachineVirtualCamera _deathCamera;
    [SerializeField] private Transform _enemyParent;
    [SerializeField] private Transform _deathEnemiesParent;
    [SerializeField] private EnemyAnimation _animator;
    private bool _death;
    [SerializeField] private int _health;
    [SerializeField] private Enemy _securesEnemy;
    [SerializeField] private GameObject[] _healthSprites; 

    private void Start()
    {
        CheckHp();
    }

    public void PlayerTarget()
    {
        _isTargetForPlayer = true;
    }
    private void Update()
    {
        if (_player != null && !_death && _player.IsDeath() == false)
        {
            if (_isTargetForPlayer == false && _enemy.remainingDistance < 3) _enemy.SetDestination(_player.transform.position);
        }
    }

    public void LookAt(Player player)
    {
        _player = player;
        _animator.SetPlayer(player);
    }

    public void Death(int g)
    {
        if(_health <= 0)
        {
            SecuresEnemyKill();
            _enemyParent.SetParent(_deathEnemiesParent);
            _death = true;
            _enemy.enabled = false;
            _enemyCollider.enabled = false;
            for (int i = 0; i < _enemyObj.Length; i++)
            {
                _enemyObj[i].SetActive(false);
            }
            _enemyObj[g].SetActive(true);
        }
        else
        {
            _health -= 1;
            CheckHp();
            _animator.GetDamage();
            SecuresEnemyKill();
        }
    }

    public void KillPlayer()
    {
        _animator.Attack();
    }

    public bool IsTarget()
    {
        return _isTargetForPlayer;
    }

    public void Speed(int speed)
    {
        if(_isTargetForPlayer == false)
        _enemy.speed = speed;
    }

    public void DisableEnableCollider()
    {
        _enemyCollider.enabled = false;
        _enemyCollider.enabled = true;
    }

    public void SecuresEnemyKill()
    {
        if (_securesEnemy != null)
        {
            _securesEnemy.KillPlayer();
        }
    }

    public void SecuresEnemy(Enemy enemy)
    {
        if (_securesEnemy == null) _securesEnemy = enemy;
        else if (enemy == null) _securesEnemy = null;
    }

    private void CheckHp()
    {
        for (int i = 0; i < _healthSprites.Length; i++)
        {
            _healthSprites[i].SetActive(false);
        }
        if (_health == 1) _healthSprites[0].SetActive(true);
        else if (_health == 2)_healthSprites[1].SetActive(true);
    }
}
