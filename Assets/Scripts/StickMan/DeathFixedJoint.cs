using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFixedJoint : MonoBehaviour
{
    [SerializeField] private Rigidbody _bonesRigidBody;
    private float step = 1f;
    private float stepUp = 2f;
    [SerializeField] private bool _isRightPoint;
    [SerializeField] private Rigidbody[] _ragdollRigidbody;
    private Vector3 _localTransformRight;
    private Vector3 _localTransformForward;

    private void OnEnable()
    {
        _localTransformRight = transform.right;
        _localTransformForward = transform.forward;
    }

    private void FixedUpdate()
    {

            if (_isRightPoint) _bonesRigidBody.velocity = (new Vector3(0, 2, 0) + _localTransformRight * 3 - _localTransformForward * 5) * step;
            else _bonesRigidBody.velocity = (new Vector3(0, stepUp, 0) + -_localTransformRight * 3 - _localTransformForward * 5) * step;
        step *= 0.99f;
        stepUp -= 0.05f;
    }

    private void Start()
    {
        Invoke(nameof(DestroyPoint), 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Flor flor))
        {
            DestroyPoint();
        }
    }

    private void DestroyPoint()
    {
        for (int i = 0; i < _ragdollRigidbody.Length; i++)
        {
            _ragdollRigidbody[i].useGravity = true;
        }
    }
}
