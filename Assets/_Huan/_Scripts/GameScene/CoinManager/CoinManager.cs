using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour, ICoinUIQuery
{
    public static CoinManager Instance { get; private set; }

    public TMP_Text coinText;

    private int coin = 0;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        UpdateCoin(9);        
    }

    private void UpdateCoin(int newValue)
    {
        coin = newValue;
        coinText.text = coin.ToString();
    }

    private void AddCoin(int value)
    {
        coin += value;
        coinText.text = coin.ToString();
    }

    private bool UseCoin(int value)
    {
        if (value > coin)
            return false;

        coin -= value;
        coinText.text = coin.ToString();
        return true;
    }

    public int GetCoin()
    {
        return coin;
    }
}
