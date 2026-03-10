using UnityEngine;

public class TheEyeOfSauron : MonoBehaviour
{
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 15f;
        Vector3 targetWorldPos = mainCam.ScreenToWorldPoint(mousePos);
        transform.LookAt(targetWorldPos);
    }
}
