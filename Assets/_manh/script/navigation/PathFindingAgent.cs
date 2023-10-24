using System.Collections;
using System.Collections.Generic;
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

    PathFindingComponent pathFinding;
    List<Vector2> pathToGo = new();
    Coroutine pathFindingCoroutine;

    public Transform FollowTransform { get => followTransform; set => followTransform = value; }

    #endregion

    public UnityEvent onAgentClearPath;

    void Start()
    {
        pathFinding = GetComponent<PathFindingComponent>();

        if(!FollowTransform && !string.IsNullOrEmpty(targetFollowTag))
        {
            FollowTransform = GameObject.FindGameObjectWithTag(targetFollowTag)?.transform;
        }

        pathFindingCoroutine = StartCoroutine(FindPathCoroutine());

        if (model == null)
            model = transform.FindSiblingWithTag("figure-model")?.transform;
    }

    private void FixedUpdate()
    {
        SimplifyPath();

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
        yield return new WaitForFixedUpdate();

        while (FollowTransform != null)
        {
            yield return pathFinding.GeneratePath(
                pathToGo.Count > 0 ? pathToGo[0] : agentTransform.position,
                //agentTransform.position,
                FollowTransform.position);

            if (pathToGo.Count > 0)
            {
                pathToGo.RemoveRange(1, pathToGo.Count - 1);
            }

            pathToGo.AddRange(pathFinding.GetGenerateResult());

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

            if(pathToGo.Count == 0)
            {
                onAgentClearPath?.Invoke();
            }
        }
    }

    public void MoveTo(Vector2 destination)
    {
        pathToGo.Clear();
        pathToGo.Add(destination);
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
