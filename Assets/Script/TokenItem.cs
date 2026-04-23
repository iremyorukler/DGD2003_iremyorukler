using UnityEngine;

public class TokenItem : MonoBehaviour
{
    [Header("Eşya Bilgileri")]
    public string itemName = "Token";
    public void PuluTopla()
    {
        InventoryManager inventory = FindFirstObjectByType<InventoryManager>();

        if (inventory != null)
        {
            inventory.AddItem(itemName); 
            Destroy(gameObject); 
        }
        else
        {
            Debug.LogError("Sahnedeki InventoryManager bulunamadı!");
        }
    }
}