using UnityEngine;
using UnityEngine.Events; 

public class EtkilesimObjesi : MonoBehaviour
{
    [Header("E'ye Basınca Ne Olsun?")]
    public UnityEvent onInteract;

    public void EtkilesimeGir()
    {
        onInteract.Invoke();
    }
}