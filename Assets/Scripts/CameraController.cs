using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1f;

    private CinemachineComposer composer;

    private void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Mouse Y") * sensitivity;

        if (vertical != 0)
        {
            composer.m_TrackedObjectOffset.y += vertical * Time.deltaTime;
            composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, 0.2f, 6f);
        }
    }
}
