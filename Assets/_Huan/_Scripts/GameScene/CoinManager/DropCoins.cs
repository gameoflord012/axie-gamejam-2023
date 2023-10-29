using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DropCoins : MonoBehaviour
{
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private int valuePerCoin = 10;
    [SerializeField] private int dropValue;
    [SerializeField] private float dropRange = 1f;

    public int DropValue { get => dropValue; set => dropValue = value; }

    public void SetCoin(int value)
    {
        dropValue = value;
    }

    public void CoinsDrop()
    {
        var dropValueRemain = dropValue;
        while (dropValueRemain >= valuePerCoin * 1.5)
        {
            var coin = GetNewCoin();
            coin.SetValue(valuePerCoin);

            dropValueRemain -= valuePerCoin;
        }

        if(dropValueRemain > 0)
        {
            var coin = GetNewCoin();
            coin.SetValue(dropValueRemain);

            coin.transform.localScale *= (float)dropValueRemain / valuePerCoin;
        }
    }

    Coin GetNewCoin()
    {
        var coin = Instantiate(coinsPrefab, 
            transform.position, 
            Quaternion.identity).GetComponent<Coin>();

        var nav = coin.transform.FindSibling<MissleNav>();

        nav.FollowPosition = (Vector2)transform.position + new Vector2(
             Random.Range(-dropRange, dropRange),
            Random.Range(-dropRange, dropRange));

        return coin;
    }
}
