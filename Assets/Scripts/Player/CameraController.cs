using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private GameObject freeLookCamera;
    [SerializeField] private CinemachineFreeLook freeLookComponent;

    public void ClickDown()
    {
        freeLookComponent.m_XAxis.m_MaxSpeed = 2000;
    }

    public void ClickUp()
    {
        freeLookComponent.m_XAxis.m_MaxSpeed = 0;
    }
}

