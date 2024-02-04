using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaveZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Collider _zoneCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Player player))
        {
            _enemy.Speed(5);
            _enemy.LookAt(player);
            Invoke(nameof(SpeedZero), 0.5f);
        }
    }

    public void DisableEnableCollider()
    {
        _zoneCollider.enabled = false;
        _zoneCollider.enabled = true;
    }

    private void SpeedZero()
    {
        _enemy.Speed(0);
    }
}
