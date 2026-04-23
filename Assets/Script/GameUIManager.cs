using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameUIManager : MonoBehaviour
{
    [Header("Economy & Tasks")]
    public int tokensCollected = 0;
    public int targetTokens = 5;
    public int currentMoney = 0;

    [Header("UI References")]
    public TextMeshProUGUI taskText;
    public TextMeshProUGUI moneyText;

    [Header("Events")]
    public UnityEvent OnMissionComplete;

    void Start()
    {
        UpdateUI();
    }

    public void AddToken()
    {
        tokensCollected++;

        if (tokensCollected >= targetTokens)
        {
            currentMoney += 5; 
            taskText.text = "Task Complete: Head to Camera Room!";
            OnMissionComplete.Invoke();
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        moneyText.text = "Balance: " + currentMoney + " TL";
        if (tokensCollected < targetTokens)
        {
            taskText.text = "Task: Find Game Tokens (" + tokensCollected + "/" + targetTokens + ")";
        }
    }
}