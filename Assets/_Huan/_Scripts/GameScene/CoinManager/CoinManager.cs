using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour, ICoinUIQuery
{
    public TMP_Text coinText;

    private int coin = 0;
    
    private void UpdateCoin(int newValue)
    {
        coin = newValue;
    }

    private void AddCoin(int value)
    {
        coin += value;
    }

    private bool UseCoin(int value)
    {
        if (value > coin)
            return false;

        coin -= value;
        return true;
    }
}
