using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private KeyCode shootKey = KeyCode.Space;
    private float _currentShootDelay = 1.0f;
    private bool _canShoot = true;

    private void Start()
    {
        WeaponPickup.OnPickupPicked += ChangeWeapon;
    }


    private void ChangeWeapon(PickupType pickupType)
    {
        switch (pickupType)
        {
            case PickupType.MachineGun:
                _currentShootDelay = 0.1f;
                break;
            
            case PickupType.ShotGun:
                _currentShootDelay = 1.5f;
                break;
            
            case PickupType.Regular:
                _currentShootDelay = 1.0f;
                break;
        }
    }
    
    void Update()
    {
        if (_canShoot)
        {
            if (Input.GetKeyDown(shootKey))
            {
                Instantiate(bulletPrefab, transform);
                _canShoot = false;
            }

            else if (Input.GetKey(shootKey))
            {
                Instantiate(bulletPrefab, transform);
                _canShoot = false;
            }

            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_currentShootDelay);
        _canShoot = true;
    }
    
}
