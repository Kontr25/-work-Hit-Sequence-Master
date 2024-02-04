using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _player;

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            _enemy.transform.LookAt(_player);
        }
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}
