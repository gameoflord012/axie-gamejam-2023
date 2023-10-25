using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MissleNav : MonoBehaviour
{
    [SerializeField] Transform followTransform;
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
        rb.velocity = transform.up * speed;

        var dir = (Vector2)(followTransform.position - transform.position).normalized;

        var rotation = Quaternion.RotateTowards(
            transform.rotation, 
            Quaternion.LookRotation(Vector3.forward, dir), 
            rotationSpeed * Time.deltaTime);

        rb.MoveRotation(rotation);
    }
}
