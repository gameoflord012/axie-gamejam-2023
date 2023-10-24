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
                MoveAgent(Extension.GetMouseWorldPos());
        }
    }

    public void MoveAgent(Vector2 dest)
    {
        var agent = transform.FindSibling<PathFindingAgent>();
        agent.MoveTo(dest);
    }
}
