using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvasRotator : MonoBehaviour
{
    [SerializeField] private Transform _convas;

    void Update()
    {
        Vector3 direction = Camera.main.transform.position - _convas.transform.position;
        Quaternion rotation = Quaternion.LookRotation(-direction);
        _convas.transform.rotation = Quaternion.Lerp(_convas.transform.rotation, rotation, 5);
    }
}
