using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    [Header("Energy Stats")]
    public float maxEnergy = 100f;
    public float currentEnergy;

    [Header("Events")]
    public UnityEvent OnEnergyDepleted;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    public void UseEnergy(float amount)
    {
        if (currentEnergy > 0)
        {
            currentEnergy -= amount * Time.deltaTime;

            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                OnEnergyDepleted.Invoke();
                Debug.Log("Energy Depleted!");
            }
        }
    }

    public void RestoreEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }
}