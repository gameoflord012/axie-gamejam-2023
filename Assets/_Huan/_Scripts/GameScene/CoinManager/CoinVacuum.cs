using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinVacuum : MonoBehaviour
{
    public UnityEvent<int> onCoinSuckValue;

    [SerializeField] private float radius;
    [SerializeField] private float innerRadius;
    [SerializeField] private LayerMask coinLayer;

    LevelAndExperience lvl;

    private void Start()
    {
        lvl = transform.FindSibling<LevelAndExperience>();
    }

    private void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.up, 0f, coinLayer);

        foreach (var hit in hits)
        {
            Coin coin = hit.collider.gameObject.GetComponent<Coin>();



            coin.OnSucked(transform);
            onCoinSuckValue?.Invoke(coin.Value);

            if (coin.Value < 0)
            {
                lvl.CurrentExp += -coin.Value;
            }
            else
            {
                CoinManager.Instance?.AddCoin(coin.Value);
            }

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
