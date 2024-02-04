using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActivator : MonoBehaviour
{
    [SerializeField] private ChooserEnemies _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Enemy enemy))
        {
            _player.PlayerCollider(true);
        }
    }
}
