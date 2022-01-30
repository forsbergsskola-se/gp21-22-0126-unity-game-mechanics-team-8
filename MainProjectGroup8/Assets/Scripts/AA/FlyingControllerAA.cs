using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControllerAA : MonoBehaviour
{
    public float speed;
    public float acceleration;

    private Rigidbody rb;

    public float rotationControl;
    private float movX, movY = 1;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        movY = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        Vector3 vel = transform.right * (movX * acceleration);
        rb.AddForce(vel);

        float dir = Vector3.Dot(rb.velocity, rb.GetRelativePointVelocity(Vector3.right));

        if (acceleration > 0)
        {
            if (dir > 0)
            {
                
            }
        }
    }
}
