using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 5f;
    public GameObject interactUI;

    void Start() { if (interactUI != null) interactUI.SetActive(false); }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            EtkilesimObjesi etkilesilen = hit.collider.GetComponent<EtkilesimObjesi>();

            if (etkilesilen != null)
            {
                if (interactUI != null) interactUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    etkilesilen.EtkilesimeGir();
                    if (interactUI != null) interactUI.SetActive(false);
                }
            }
            else { if (interactUI != null) interactUI.SetActive(false); }
        }
        else { if (interactUI != null) interactUI.SetActive(false); }
    }
}