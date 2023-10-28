using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoins : MonoBehaviour
{
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private int count;

    public void SetCoin(int value)
    {
        count = value;
    }

    public void CoinsDrop()
    {
        Coin newCoin = Instantiate(coinsPrefab, transform.position, Quaternion.identity).GetComponent<Coin>();

        newCoin.SetValue(count);
    }
}
