using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

using Point = System.Drawing.Point;

[RequireComponent(typeof(PathFindingComponent))]
public class PathFindingAgent : MonoBehaviour
{
    #region variables
    [SerializeField] Transform followTransform;
    [SerializeField] Transform agentTransform;
    [SerializeField] Transform model;
    [SerializeField] string targetFollowTag;
    [Space]
    [SerializeField] float distanceThreshold = 0.1f;
    [SerializeField] float rescanNavTime = 1f;
    [SerializeField] float speed = 2;
    [SerializeField] [ReadOnly] Vector2 followPosition;

    PathFindingComponent pathFinding;
    List<Vector2> pathToGo = new();
    Coroutine pathFindingCoroutine;

    public Transform FollowTransform { get => followTransform; set => followTransform = value; }
    public float Speed { get => speed; set => speed = value; }

    #endregion

    public UnityEvent onAgentClearPath;

    private void Awake()
    {
        pathFinding = GetComponent<PathFindingComponent>();
        followPosition = agentTransform.position;

        if (!FollowTransform && !string.IsNullOrEmpty(targetFollowTag))
        {
            FollowTransform = GameObject.FindGameObjectWithTag(targetFollowTag)?.transform;
        }
    }

    void Start()
    {
        pathFindingCoroutine = StartCoroutine(FindPathCoroutine());

        if (model == null)
            model = transform.FindSiblingWithTag("figure-model")?.transform;
    }

    private void FixedUpdate()
    {
        SimplifyPath();

        followPosition = FollowTransform ? FollowTransform.position : followPosition;

        if (pathToGo.Count > 0)
        {
            Vector2 nextPoint = pathToGo[0];
            var dir = ((Vector3)nextPoint - agentTransform.position).normalized;
            agentTransform.position += dir * speed * Time.deltaTime;

            if(model)
            {
                if (dir.x > 0)
                    model.localScale = new Vector2(-Mathf.Abs(model.localScale.x), model.localScale.y);
                else
                    model.localScale = new Vector2(Mathf.Abs(model.localScale.x), model.localScale.y);
            }
        }
    }

    IEnumerator FindPathCoroutine()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            if(IsAgentArriveDestination() || IsValidPathToGo())
            {
                continue;
            }

            yield return pathFinding.GeneratePath(
                agentTransform.position,
                followPosition);

            pathToGo = pathFinding.GetGenerateResult().ToList();

            yield return new WaitForSeconds(rescanNavTime);
        }
    }

    private bool IsValidPathToGo()
    {
        return 
            pathToGo.Count == 0 && IsAgentArriveDestination() ||
            pathToGo.Count > 0 &&
            pathFinding.CheckPath(pathToGo) && Vector2.Distance(pathToGo.Last(), followPosition) < distanceThreshold;
    }

    private bool IsAgentArriveDestination()
    {
        return Vector2.Distance(agentTransform.position, followPosition) < distanceThreshold;
    }

    private void SimplifyPath()
    {
        while (
            pathToGo.Count > 0 &&
            Vector2.Distance(agentTransform.position, pathToGo[0]) < distanceThreshold)
        {
            pathToGo.RemoveAt(0);

            if(pathToGo.Count == 0)
            {
                onAgentClearPath?.Invoke();
            }
        }
    }

    public void MoveTo(Vector2 destination)
    {
        pathToGo.Clear();
        followPosition = destination;
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
