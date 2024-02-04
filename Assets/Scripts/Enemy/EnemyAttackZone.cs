using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _enemyTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Enemy enemy))
        {
            if(enemy.transform != _enemyTransform) enemy.SecuresEnemy(_enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.SecuresEnemy(null);
        }
    }
}
