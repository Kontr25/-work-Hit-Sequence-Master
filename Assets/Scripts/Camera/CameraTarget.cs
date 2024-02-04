using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cameraLeft;
    [SerializeField] private CinemachineVirtualCamera _cameraRight;
    [SerializeField] private Transform _enemyParent;
    private List<Transform> _enemiesList = new List<Transform>();

    public void TargetPosition()
    {
        if(_cameraLeft.Priority < _cameraRight.Priority)
        {
            _cameraLeft.Priority += 10;
        }
        else
        {
            _cameraRight.Priority += 10;
        }
        transform.position = Vector3.zero;
        _enemiesList.Clear();
        foreach(Transform child in _enemyParent)
        {
            _enemiesList.Add(child);
        }
        for (int i = 0; i < _enemiesList.Count; i++)
        {
            transform.position += _enemiesList[i].position;
        }
        if (_enemiesList.Count > 1)
        {
            transform.position = transform.position / _enemiesList.Count;
        }
    }
}
