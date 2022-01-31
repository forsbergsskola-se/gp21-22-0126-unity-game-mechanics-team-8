using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private string fireButtonName = "Fire1";
    private float _currentShootDelay = 1.0f;
    private PickupType _pickupType = PickupType.ShotGun;
    private bool _canShoot = true;
    private int _currentAmmo;
    [SerializeField] private int baseDamage = 10;

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
        if (Input.GetButtonDown(fireButtonName))
        {
            TryShoot();
            StartCoroutine(ShootDelay());
        }

        else if (Input.GetButton(fireButtonName) && _pickupType == PickupType.MachineGun && _canShoot)
        {
            MakeBullet(Vector3.right, baseDamage / 2);
            StartCoroutine(ShootDelay());
            _canShoot = false;
        }
    }


    private void MakeBullet(Vector3 travelVector , int damageAmount = 10, Vector3 addVector =  new Vector3(), float scalar = 1)
    {
        var tempBullet = Instantiate(bulletPrefab, transform);
        tempBullet.GetComponent<Bullet>().travelVector = travelVector + addVector;
        tempBullet.GetComponent<Bullet>().damageAmount = damageAmount;
        tempBullet.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f) * scalar;
    }
    
    private void TryShoot()
    {
        if (_canShoot)
        {
            if (_pickupType != PickupType.ShotGun)
            {
                MakeBullet(Vector3.right);
            }
            if (_pickupType == PickupType.ShotGun)
            {
                ShotgunPattern();
            }
            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private void ShatterPattern()
    {
        
    }
    
    private void MachineGunPattern()
    {
        _currentShootDelay = 3f;
        for (int i = 0; i < 2; i++)
        {
            if(_canShoot) 
                MakeBullet(Vector3.right);
            StartCoroutine(ShootDelay());
        }
    }
    
    private void ShotgunPattern()
    {
        Vector3 addVector = new Vector3(0, -0.8f, 0);
        for (int i = 0; i < 5; i++)
        {
            addVector += new Vector3(0, 0.2f, 0);
            MakeBullet(Vector3.right, baseDamage / 3, addVector, 0.5f);
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_currentShootDelay);
        _canShoot = true;
    }
    
}
