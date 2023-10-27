using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    public int Coin { get => coin; }

    public TMP_Text coinText;
    [SerializeField] private int starterCoin = 10;

    private int coin;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        coin = starterCoin;
        UpdateCoin(coin);        
    }

    private void UpdateCoin(int newValue)
    {
        coin = newValue;
        coinText.text = coin.ToString();
    }

    public void AddCoin(int value)
    {
        coin += value;
        coinText.text = coin.ToString();
    }

    public bool UseCoin(int value)
    {
        if (value > coin)
            return false;

        coin -= value;
        coinText.text = coin.ToString();
        return true;
    }
}
