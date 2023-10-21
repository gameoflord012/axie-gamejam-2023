using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ColliderFilter : MonoBehaviour
{
    Collider2D col;
    HashSet<Collider2D> touchCols = new();

    public UnityEvent<Collider2D> onTriggerEnter;
    public UnityEvent<Collider2D> onTriggerExit;
    public UnityEvent<Collider2D> onLastTriggerExit;

    [SerializeField] string[] filterTags;
    [SerializeField] LayerMask filterLayers;

    [SerializeField] bool debugMessage = false;

    public List<Collider2D> GetTouchCols()
    {
        return touchCols.ToList();
    }

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    bool CheckValid(Collider2D col)
    {
        if (filterLayers.value == 0 && filterTags.Count() == 0) return true;
        if ((filterLayers.value & col.gameObject.layer) != 0) return true;

        foreach(string tag in filterTags)
        {
            if (col.CompareTag(tag)) return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CheckValid(collision))
        {
            touchCols.Add(collision);
            onTriggerEnter.Invoke(collision);

            if (debugMessage)
                Debug.Log("In" + collision.gameObject + " " + touchCols.Count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckValid(collision))
        {
            touchCols.Remove(collision);
            onTriggerExit.Invoke(collision);

            if (touchCols.Count == 0)
                onLastTriggerExit.Invoke(collision);

            if (debugMessage)
                Debug.Log("Out" + collision.gameObject + " " + touchCols.Count);
        }
    }
}
