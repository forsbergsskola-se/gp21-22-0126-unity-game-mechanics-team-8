using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float parachuteForce = .5f;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (playerInputController.ParachuteInput)
        {
            myRigidbody.AddForce(Vector3.up * parachuteForce);
            
        }
    }
}

