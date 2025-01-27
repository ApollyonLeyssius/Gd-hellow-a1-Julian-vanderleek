using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Voor de tekstweergave

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText; // Verwijzing naar de tekst in de UI
    private int coinCount = 0; // Teller om de munten bij te houden

    void Start()
    {
        // Zorg ervoor dat de tekst in de UI wordt ingesteld
        UpdateCoinText();

        // Luister naar het evenement van Collectable
        Collectable.OnCollected += IncreaseCoinCount;
    }

    private void OnDestroy()
    {
        // Verwijder de listener wanneer dit object wordt vernietigd
        Collectable.OnCollected -= IncreaseCoinCount;
    }

    private void IncreaseCoinCount()
    {
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {coinCount}";
        }
    }
}