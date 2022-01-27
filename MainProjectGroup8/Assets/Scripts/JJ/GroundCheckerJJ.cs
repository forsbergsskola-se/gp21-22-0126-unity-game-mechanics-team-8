using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerJJ : MonoBehaviour
{
    public bool isGrounded { get; private set; }

    [SerializeField]
    private float groundCheckLength = 1f;

    [SerializeField]
    private float groundCheckRadius = 0.5f;

    [SerializeField]
    private LayerMask groundLayers;
	
    private void Update()
    {
        var ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.SphereCast(ray, groundCheckRadius, groundCheckLength, groundLayers);
        // isGrounded = Physics.SphereCast(ray, groundCheckRadius, groundCheckLength);
        Debug.Log(isGrounded);
        
        Debug.DrawLine(transform.position, Vector3.down*groundCheckLength);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position+Vector3.down*groundCheckLength, groundCheckRadius);
    }
}
