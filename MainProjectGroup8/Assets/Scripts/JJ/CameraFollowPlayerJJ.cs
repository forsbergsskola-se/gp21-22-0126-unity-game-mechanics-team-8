using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerJJ : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    
    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float smoothingSpeed = 0.2f;

    private void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        var desieredPosition = playerTransform.position + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, desieredPosition, smoothingSpeed);
    }
}
