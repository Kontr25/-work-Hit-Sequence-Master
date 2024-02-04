using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _blood;
    private ParticleSystem.MainModule _mainMod;

    private void Start()
    {
        _mainMod = _blood.main;
        Invoke(nameof(Slow), 0.1f);
    }

    private void Slow()
    {
        _mainMod.simulationSpeed = 0.1f;
    }
}
