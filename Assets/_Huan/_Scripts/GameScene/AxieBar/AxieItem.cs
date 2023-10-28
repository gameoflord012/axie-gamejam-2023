using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxieItem : AbstractItem
{
    public AxieSO axie;

    private void Start()
    {
        image.sprite = axie.sprite;  
    }

    public override void PlaceItem(Vector2 position)
    {
        Instantiate(axie.prefab, position, Quaternion.identity);
        GetComponentInParent<AxieItemSlot>().StartCooldown();

        CoinManager.Instance.UseCoin(axie.placementCost);
    }

    public override int GetPrice()
    {
        return axie.placementCost;
    }
}
