using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public float openAngle = 90f; // Kapının açılacağı açı
    public float smoothSpeed = 2f; // Açılma hızı

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Kapının başlangıç (kapalı) halini kaydet
        closedRotation = transform.localRotation;
        // Açık halini hesapla (Y ekseninde 90 derece dönmüş hali)
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    public void Interact()
    {
        isOpen = !isOpen; // Durumu tersine çevir
        Debug.Log("Door is " + (isOpen ? "Opening" : "Closing"));
    }

    void Update()
    {
        // Her karede, kapıyı hedef rotasyona doğru yumuşakça döndür
        Quaternion target = isOpen ? openRotation : closedRotation;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smoothSpeed);
    }
}