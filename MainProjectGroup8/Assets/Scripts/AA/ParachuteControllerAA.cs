using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float parachuteForce = .5f;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    [SerializeField] private BooleanValue parachuteIsOn;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (playerInputController.ParachuteInput && parachuteIsOn.BoolValue)
        {
            myRigidbody.AddForce(Vector3.up * parachuteForce * Random.Range(0.5f,1.5f));
            
        }
    }
}

