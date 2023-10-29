using UnityEngine;
using UnityEngine.Events;

public class SelectableManager : MonoBehaviour
{
    public static SelectableManager Current()
    {
        return FindAnyObjectByType<SelectableManager>();
    }

    public UnityEvent<GameObject> onSelectableChanged;

    [SerializeField] LayerMask selectableLayer;
    [SerializeField] bool debug;

    [SerializeField][ReadOnly] GameObject primarySelection;
    [SerializeField][ReadOnly] GameObject secondarySelection = null;

    public GameObject PrimarySelection { get => primarySelection; }
    public GameObject SecondarySelection { get => secondarySelection; }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var selection = GetSelection();
            if(selection != primarySelection)
            {
                primarySelection = selection;
                onSelectableChanged?.Invoke(primarySelection);
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            var selection = GetSelection();

            if (selection != secondarySelection)
            {
                secondarySelection = selection;
                onSelectableChanged?.Invoke(secondarySelection);
            }
        }
    }

    GameObject GetSelection()
    {
        if (UIHelper.Current().IsPointerOverUIElement())
        {
            return null;
        }

        var col = Physics2D.Raycast(
            Extension.GetMouseWorldPos(),
            Vector2.zero, 0,
            selectableLayer)
            .collider;

        if (debug)
            Debug.Log(col);

        return col ? col.gameObject : null;
    }
}
