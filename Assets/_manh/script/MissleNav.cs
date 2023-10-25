using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MissleNav : MonoBehaviour
{
    public UnityEvent onMissleReached;

    [SerializeField] Transform followTransform;
    [SerializeField] float distanceOffset = 1;
    [SerializeField] float speed = 5;
    [SerializeField] float rotationSpeed = 10;

    Rigidbody2D rb;

    public Transform FollowTransform { get => followTransform; set => followTransform = value; }

    private void Start()
    {
        rb = transform.FindSibling<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(followTransform.position, transform.position) < distanceOffset)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        var dis = (Vector2)(followTransform.position - transform.position);

        rb.velocity = transform.up * speed * dis.magnitude;

        var rotation = Quaternion.RotateTowards(
            transform.rotation, 
            Quaternion.LookRotation(Vector3.forward, dis), 
            rotationSpeed * Time.deltaTime);

        rb.MoveRotation(rotation);
    }
}
