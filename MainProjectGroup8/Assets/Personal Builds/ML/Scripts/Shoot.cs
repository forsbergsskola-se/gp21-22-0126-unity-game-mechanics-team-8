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
    private PickupType _pickupType = PickupType.Regular;
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
                _currentShootDelay = 0.3f;
                break;
            
            case PickupType.ShotGun:
                _currentShootDelay = 1.5f;
                break;
            
            case PickupType.Regular:
                _currentShootDelay = 1.0f;
                break;
        }

        _pickupType = pickupType;
    }
    
    void Update()
    {
        if (_canShoot)
        {
            if (Input.GetKeyDown(shootKey))
            {
                TryShoot();
            }

            else if (Input.GetKey(shootKey) && _pickupType == PickupType.MachineGun)
            {
                Instantiate(bulletPrefab, transform);
                _canShoot = false;
            }

            StartCoroutine(ShootDelay());
        }
    }

    private void TryShoot()
    {
        if (_canShoot)
        {
            if (_pickupType == PickupType.Regular)
            {
                Instantiate(bulletPrefab, transform);
            }
            else if (_pickupType == PickupType.ShotGun)
            {
                ShotgunPattern();
            }
            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }
    
    private void ShotgunPattern()
    {
        Vector3 addVector = Vector3.forward;
        
        for (int i = 0; i < 5; i++)
        {
            var bullet = Instantiate(bulletPrefab, transform);
            bullet.GetComponent<Bullet>().travelVector = Vector3.forward;
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_currentShootDelay);
        _canShoot = true;
    }
    
}
