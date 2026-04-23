using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineCamera playerCam;
    public CinemachineCamera securityCam1;
    public CinemachineCamera securityCam2;

    public void ShowSecurity1() { ResetPriorities(); if (securityCam1 != null) securityCam1.Priority = 20; }
    public void ShowSecurity2() { ResetPriorities(); if (securityCam2 != null) securityCam2.Priority = 20; }
    public void ShowPlayer() { ResetPriorities(); if (playerCam != null) playerCam.Priority = 20; }

    private void ResetPriorities()
    {
        if (playerCam != null) playerCam.Priority = 10;
        if (securityCam1 != null) securityCam1.Priority = 10;
        if (securityCam2 != null) securityCam2.Priority = 10;
    }
}