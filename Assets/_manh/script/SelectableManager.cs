using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectableManager : MonoBehaviour
{
    public UnityEvent<GameObject> onSelectableChanged;

    [SerializeField] LayerMask selectableLayer;
    [SerializeField] bool debug;

    [SerializeField][ReadOnly] GameObject currentSelectedGameObject;
    [SerializeField][ReadOnly] GameObject previousSlectable = null;

    public GameObject PreviousSlectable { get => previousSlectable; }
    public GameObject CurrentSelectedGameObject { get => currentSelectedGameObject; }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var col = Physics2D.Raycast(
                Extension.GetMouseWorldPos(),
                Vector2.zero, 0,
                selectableLayer)
                .collider;

            previousSlectable = currentSelectedGameObject;
            currentSelectedGameObject = col ? col.gameObject : null;

            if (previousSlectable != currentSelectedGameObject)
                onSelectableChanged?.Invoke(currentSelectedGameObject);

            if (debug)
                Debug.Log(col);
        }
    }
}
