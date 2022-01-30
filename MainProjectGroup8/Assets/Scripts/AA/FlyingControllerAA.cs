using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private PlayerInputControllerAA playerInputController;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (playerInputController.FlyingInput)
        {
            myRigidbody.AddForce(Vector3.up * flyForce);
        }
    }
}

