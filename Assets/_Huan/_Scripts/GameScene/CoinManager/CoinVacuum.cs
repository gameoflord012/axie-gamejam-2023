using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVacuum : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float innerRadius;
    [SerializeField] private LayerMask coinLayer;

    private void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, 0f, coinLayer);

        foreach (var hit in hits)
        {
            Coin coin = hit.collider.gameObject.GetComponent<Coin>();

            coin.OnSucked(transform);
            CoinManager.Instance.AddCoin(coin.Value);
            coin.SetValue(0);
        }

        CheckCoinAdded();
    }

    private void CheckCoinAdded()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, innerRadius, Vector2.up, 0f, coinLayer);

        foreach (var hit in hits)
        {
            Destroy(hit.collider.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, innerRadius);
    }
}
