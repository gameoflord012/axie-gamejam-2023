using System.Collections;
using System.Collections.Generic;
using Algorithms;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

using Point = System.Drawing.Point;

public class PathFindingAgent : MonoBehaviour
{

    [SerializeField] Transform followTransform;
    [SerializeField] Transform agentTransform;

    [SerializeField] Board currentBoard;
    [Space]
    [SerializeField] float speed = 2;
    [SerializeField] float rescanNavTime = 1f;
    [SerializeField] float distanceThreshold = 0.1f;
    [SerializeField] bool isRunning = false;

    [SerializeField] string targetFollowTag;

    PathFindingComponent pathFinding;
    List<Vector2> pathToGo = new();

    Coroutine pathFindingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        pathFinding = GetComponent<PathFindingComponent>();

        if(!followTransform)
        {
            followTransform = GameObject.FindGameObjectWithTag(targetFollowTag)?.transform;
        }

        if(!currentBoard)
        {
            currentBoard = GameObject.FindGameObjectWithTag("main-board")?.GetComponent<Board>();
            if (!currentBoard) Debug.LogWarning("Main board not found on any scenes");
        }

        if(followTransform)
            pathFindingCoroutine = StartCoroutine(FindPathCoroutine());
    }

    private void FixedUpdate()
    {
        SimplifyPath();

        if (pathToGo.Count > 0)
        {
            Vector2 nextPoint = pathToGo[0];
            agentTransform.position += ((Vector3)nextPoint - agentTransform.position).normalized * speed * Time.deltaTime;
        }
    }

    IEnumerator FindPathCoroutine()
    {
        yield return new WaitForFixedUpdate();

        while (true)
        {
            yield return pathFinding.GeneratePath(
                currentBoard.GetBoardGrid(),
                currentBoard.WorldPosToGrid(pathToGo.Count > 0 ? pathToGo[0] : agentTransform.position),
                currentBoard.WorldPosToGrid(followTransform.position));

            if (pathToGo.Count > 0)
            {
                pathToGo.RemoveRange(1, pathToGo.Count - 1);
            }

            foreach (var gridPos in pathFinding.GetGenerateResult())
            {
                pathToGo.Add(currentBoard.GridToWorldPos(new Vector2Int(gridPos.X, gridPos.Y)));
            }

            yield return new WaitForSeconds(rescanNavTime);
        }
    }

    private void SimplifyPath()
    {
        while (
            pathToGo.Count > 0 &&
            Vector2.Distance(agentTransform.position, pathToGo[0]) < distanceThreshold)
        {
            pathToGo.RemoveAt(0);
        }

        for(int idx = 1; idx < pathToGo.Count; idx++)
        { 
            while (idx + 1 < pathToGo.Count && 
                Mathf.Approximately(
                    Vector2.Angle(
                        pathToGo[idx] - pathToGo[idx - 1],
                        pathToGo[idx + 1] - pathToGo[idx]),
                    0))
            {
                pathToGo.RemoveAt(idx);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        for(int i = 1; i < pathToGo.Count; i++)
        {
            Gizmos.DrawLine(pathToGo[i - 1], pathToGo[i]);
            Gizmos.DrawSphere(pathToGo[i], 0.2f);
        }
    }
}
