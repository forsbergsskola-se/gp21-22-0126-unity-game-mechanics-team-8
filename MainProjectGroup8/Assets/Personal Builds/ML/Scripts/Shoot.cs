using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private string fireButtonName = "Fire1";
    [SerializeField] private List<string> possibleTargets;
    [SerializeField] private float baseDamage = 10f;
    [SerializeField] private float baseBulletSpeed = 10f;
    [SerializeField] Vector3 forwardVector = Vector3.right;
    
    private float _currentShootDelay = 1.0f;
    private PickupType _pickupType = PickupType.Regular;
    private bool _canShoot = true;
    private int _currentAmmo;

    public delegate void ShotFiredDelegate();
    public static event ShotFiredDelegate OnShotFired;

    private void Start()
    {
        ChangeWeapon(PickupType.Regular);
        WeaponPickup.OnPickupPicked += ChangeWeapon;
        WeaponUIHandler.OnOutOfAmmo += ChangeWeapon;
        Bullet.OnReturnHitLocation += ShatterPattern;
    }
    
    private void ChangeWeapon(PickupType pickupType)
    {
        switch (pickupType)
        {
            case PickupType.Shatter:
                _currentShootDelay = 1.7f;
                break;
            
            case PickupType.ShotGun:
                _currentShootDelay = 1.5f;
                break;
            
            case PickupType.Regular:
                _currentShootDelay = 0.5f;
                break;
        }

        _pickupType = pickupType;
    }
    
    void Update()
    {
        if (Input.GetButtonDown(fireButtonName))
        {
            TryShoot();
        }

        else if (Input.GetButton(fireButtonName) && _pickupType == PickupType.MachineGun && _canShoot)
        {
            MakeBullet(transform.position,forwardVector, baseDamage / 2f);
            StartCoroutine(ShootDelay());
            _canShoot = false;
        }
    }


    private void MakeBullet(Vector3 bulletPos, Vector3 travelVector , float damageAmount = 10, Vector3 addVector =  new Vector3(), float bulletScale = 1, float moveSpeed = 10.0f, bool returnHitLocation = false)
    {
        var tempBullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
        tempBullet.GetComponent<Bullet>().travelVector = travelVector + addVector;
        tempBullet.GetComponent<Bullet>().damageAmount = damageAmount;
        tempBullet.GetComponent<Bullet>().returnHitLocation = returnHitLocation;
        tempBullet.GetComponent<Bullet>().moveSpeed = moveSpeed;
        tempBullet.GetComponent<Bullet>().possibleTargets = possibleTargets;
        tempBullet.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f) * bulletScale;
    }

    
    
    private void TryShoot()
    {
        if (_canShoot)
        {
            switch (_pickupType)
            {
                case PickupType.Regular:
                    MakeBullet(transform.position, Vector3.right);
                    break;
                case PickupType.ShotGun:
                    ShotgunPattern();
                    ShotFired();
                    break;
                case PickupType.Shatter:
                    MakeBullet( transform.position, forwardVector, baseDamage, Vector3.zero, 1.5f, baseBulletSpeed * 0.8f, true);
                    ShotFired();
                    break;
            }

            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private void ShotFired()
    {
        if (OnShotFired != null)
            OnShotFired();
    }
    
    
    private void ShatterPattern(Vector3 shotLocation)
    {
        int numberPellets = 8;
        for (int i = 0; i < numberPellets; i++)
        {
            float angle = i * 360 / numberPellets;
            var xMod = MathF.Cos(angle * (Mathf.PI / 180.0f));
            var yMod  = MathF.Sin(angle * (Mathf.PI / 180.0f));
            Vector3 moveVec = new Vector3(1 * xMod, 1 * yMod);
            Debug.Log(moveVec.x);

            MakeBullet(shotLocation,moveVec, baseDamage / 3, Vector3.zero, 0.4f, baseBulletSpeed / 2);
        }
    }
    
    private void MachineGunPattern()
    {
        _currentShootDelay = 3f;
        for (int i = 0; i < 2; i++)
        {
            if(_canShoot) 
              //  MakeBullet(Vector3.right);
            StartCoroutine(ShootDelay());
        }
    }
    
    private void ShotgunPattern()
    {
        Vector3 addVector = new Vector3(0, -0.8f, 0);
        for (int i = 0; i < 5; i++)
        {
            addVector += new Vector3(0, 0.2f, 0);
            MakeBullet(transform.position,forwardVector, baseDamage / 3, addVector, 0.5f);
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_currentShootDelay);
        _canShoot = true;
    }
    
}
