using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void Jump(Transform wave)
    {
        _rigidbody.AddForce(transform.up*5 + wave.transform.forward * 4, ForceMode.Impulse);
        int i = Random.Range(0, 2);
        if(i == 1)
        {
            _rigidbody.angularVelocity = new Vector3(1, 2, 3);
        }
    }
}
