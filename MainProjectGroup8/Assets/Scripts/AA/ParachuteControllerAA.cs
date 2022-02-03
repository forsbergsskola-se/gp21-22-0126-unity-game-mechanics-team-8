using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float parachuteForce = .5f;
    SerializeField] private float parachuteOpeningTime = .5f;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    [SerializeField] private BooleanValue parachuteIsOn;
    void Start()
    {
        
    }
    
    void Update()
    {
        Invoke(nameof(OpenParachute), parachuteOpeningTime);
    }

    private void OpenParachute()
    {
        if (playerInputController.ParachuteInput && parachuteIsOn.BoolValue)
        {
            var randomForceMultiplier = Random.Range(0.8f, 1.5f);
            myRigidbody.AddForce(Vector3.up * parachuteForce * randomForceMultiplier);
        }
    }
}

