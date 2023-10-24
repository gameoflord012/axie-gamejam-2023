using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCommands : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            MoveAgent(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void MoveAgent(Vector2 dest)
    {
        var agent = transform.FindSibling<PathFindingAgent>();
        agent.MoveTo(dest);
    }
}
