using UnityEngine;
using Unity.Cinemachine;

public class KameraGecis : MonoBehaviour
{
    public CinemachineCamera kamera1; 
    public CinemachineCamera kamera2;
    public CinemachineCamera kamera3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            kamera1.Priority = 11; kamera2.Priority = 10; kamera3.Priority = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            kamera1.Priority = 10; kamera2.Priority = 11; kamera3.Priority = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            kamera1.Priority = 10; kamera2.Priority = 10; kamera3.Priority = 11;
        }
    }
}