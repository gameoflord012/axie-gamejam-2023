using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MissleNav : MonoBehaviour
{
    public UnityEvent<MissleNav> onMissleReached;

    [SerializeField] Transform followTransform;
    [SerializeField] float travelDuration = 2f;
    [SerializeField][ReadOnly] float timer;

    //[SerializeField] float distanceOffset = 1;
    //[SerializeField] float rotationSpeed = 10;
    Rigidbody2D rb;

    bool isReached = false;
    Vector2 startPosition;
    Vector2 followPosition;

    public Transform FollowTransform { get => followTransform; set => followTransform = value; }

    private void Start()
    {
        rb = transform.FindSibling<Rigidbody2D>();
        isReached = false;
        startPosition = transform.position;
        timer = 0;
    }

    private void FixedUpdate()
    {
        followPosition = FollowTransform ? FollowTransform.position : followPosition;

        if(timer > travelDuration)
        {
            if(!isReached)
            {
                isReached = true;
                onMissleReached?.Invoke(this);
            }
        }
        else
        {
            var dir = followPosition - (Vector2)transform.position;
            rb.velocity = dir.normalized * (dir.magnitude / (travelDuration - timer));

            timer += Time.fixedDeltaTime;
        }
    }

    #region comments
    //private void FixedUpdate()
    //{
    //    nextFollowPosition = FollowTransform ? FollowTransform.position : nextFollowPosition;

    //    if(Vector2.Distance(nextFollowPosition, transform.position) < distanceOffset)
    //    {
    //        if(!isReached)
    //        {
    //            isReached = true;
    //            onMissleReached?.Invoke(this);
    //        }

    //        rb.velocity = Vector2.zero;
    //        return;
    //    }

    //    isReached = false;

    //    var dis = nextFollowPosition - (Vector2)transform.position;

    //    rb.velocity = transform.up * speed * dis.magnitude;

    //    var rotation = Quaternion.RotateTowards(
    //        transform.rotation, 
    //        Quaternion.LookRotation(Vector3.forward, dis), 
    //        rotationSpeed * Time.deltaTime);

    //    rb.MoveRotation(rotation);
    //}
    #endregion
}
