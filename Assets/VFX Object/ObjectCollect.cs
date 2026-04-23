using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    public GameObject vfxPrefab; 

    void OnMouseDown()
    {
        if (vfxPrefab != null)
        {
            Instantiate(vfxPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}