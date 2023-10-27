using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] bool debug;

    SelectableManager selectableManager;


    private void Start()
    {
        selectableManager = GetComponentInChildren<SelectableManager>();
        selectableManager?.onSelectableChanged.AddListener(MoveAgentToNewPosition);
    }

    private void MoveAgentToNewPosition(GameObject selectable)
    {
        if (selectableManager.CurrentSelectedGameObject == null && selectableManager.PreviousSlectable != null)
        {
            var command = selectableManager.PreviousSlectable.transform.FindSibling<FigureCommands>();
            if (command)
            {
                command.MoveAgent(Extension.GetMouseWorldPos());
            }
        }
    }
}

