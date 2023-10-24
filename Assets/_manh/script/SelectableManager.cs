using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableManager : MonoBehaviour
{
    [SerializeField] GameObject currentSelectedGameObject;
    [SerializeField] bool debug;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var col = Physics2D.Raycast(
                Extension.GetMouseWorldPos(),
                Vector2.zero, 0,
                1 << LayerMask.NameToLayer("selectable"))
                .collider;

            currentSelectedGameObject = col ? col.gameObject : null;

            if (debug)
                Debug.Log(col);
        }
    }
}
