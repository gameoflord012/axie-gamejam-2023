using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCommands : MonoBehaviour
{
    [SerializeField] bool debug;
    private void Update()
    {
        if(debug)
        {
            if (Input.GetMouseButtonDown(0))
            MoveAgent(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        
    }

    public void MoveAgent(Vector2 dest)
    {
        var agent = transform.FindSibling<PathFindingAgent>();
        var state = transform.FindSibling<StateController>();

        if(state.CurrentStateString != "follow-target")
        {
            state.ChangeToState("follow-target");
        }

        agent.MoveTo(dest);
    }
}
