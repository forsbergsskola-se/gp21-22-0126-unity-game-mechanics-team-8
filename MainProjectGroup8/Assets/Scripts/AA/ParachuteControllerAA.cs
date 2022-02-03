using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float parachuteForce = .5f;
    [SerializeField] private float parachuteOpeningTime = .5f;
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private BooleanValue parachuteIsOn;
    
    void Update()
    {
        Invoke(nameof(OpenParachute), parachuteOpeningTime);
    }

    private void OpenParachute()
    {
        if (playerInputController.ParachuteInput && parachuteIsOn.BoolValue && !playerInputController.FlyingInput)
        {
            var randomForceMultiplier = Random.Range(0.8f, 1.5f);
            if(myRigidbody.velocity.y < 0)
                myRigidbody.AddForce(Vector3.up * parachuteForce * randomForceMultiplier);
            
        }
    }
}

