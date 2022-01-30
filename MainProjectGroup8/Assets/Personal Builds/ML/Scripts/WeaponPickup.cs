using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    ShotGun, MachineGun, Bounce, Regular
}

public class WeaponPickup : MonoBehaviour
{
    public PickupType pickupType;

    public delegate void PickupPickedDelegate(PickupType thePickupType);

    public static event PickupPickedDelegate OnPickupPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHasPickup();
            Destroy(gameObject);
        }
    }

    private void PlayerHasPickup()
    {
        if (OnPickupPicked != null)
        {
            OnPickupPicked(pickupType);
        }
    }
    
}
