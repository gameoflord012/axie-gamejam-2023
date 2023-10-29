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
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!UIHelper.Current().IsPointerOverUIElement())
            {
                if (selectableManager.PrimarySelection == null) return;

                var command = selectableManager.PrimarySelection.transform.FindSibling<FigureCommands>();
                if (command)
                {
                    command.MoveAgent(Extension.GetMouseWorldPos());
                }
            }
        }
    }
}

