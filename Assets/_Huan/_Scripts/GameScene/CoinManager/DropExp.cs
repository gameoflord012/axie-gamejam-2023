using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DropExp : MonoBehaviour
{
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private int valuePerCoin = 10;
    [SerializeField] private int dropValue;
    [SerializeField] private float dropRange = 1f;
    [SerializeField] private bool negativeDropValue = false;


    public void CoinsDrop()
    {
        var dropValueRemain = transform.FindSibling<LevelAndExperience>().GetDropExp();

        while (dropValueRemain >= valuePerCoin * 1.5)
        {
            var coin = GetNewCoin();

            coin.SetValue(valuePerCoin * (negativeDropValue ? -1 : 1));

            dropValueRemain -= valuePerCoin;
        }

        if(dropValueRemain > 0)
        {
            var coin = GetNewCoin();
            coin.SetValue((int) dropValueRemain * (negativeDropValue ? -1 : 1));

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
