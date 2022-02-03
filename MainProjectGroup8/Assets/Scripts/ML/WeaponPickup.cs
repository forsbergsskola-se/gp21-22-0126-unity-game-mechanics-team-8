using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    ShotGun, MachineGun, Bounce, Shatter, Regular
}

public class WeaponPickup : MonoBehaviour
{
    public PickupType pickupType;
    private float rotationAmount = 0;

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

    private void Update()
    {
        rotationAmount = 10f * Time.deltaTime;
        transform.Rotate(new Vector3(0,1 ,0), rotationAmount);

        if (rotationAmount >= 360)
            rotationAmount = 0;
    }
}
