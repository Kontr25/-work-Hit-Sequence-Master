using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _thrower;

    private void Start()
    {
        _rigidbody.AddForce(transform.forward * 30, ForceMode.Impulse);
        Destroy(_thrower, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Environment environment))
        {
            environment.Jump(transform);
        }
    }
}
