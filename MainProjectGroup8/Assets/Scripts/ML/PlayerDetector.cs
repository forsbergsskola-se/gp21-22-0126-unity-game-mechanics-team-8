using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private bool PlayerSpotted = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerSpotted = true;
            gameObject.GetComponentInParent<Shoot_Enemy>().Attack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerSpotted = true;
            gameObject.GetComponentInParent<Shoot_Enemy>().Attack();
        }
    }
    
}
