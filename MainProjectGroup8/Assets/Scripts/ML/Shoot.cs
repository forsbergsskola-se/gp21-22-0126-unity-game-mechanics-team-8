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
    [SerializeField] private float baseDamage = 10f;
    [SerializeField] private float baseBulletSpeed = 1f;
    [SerializeField] Vector3 forwardVector = Vector3.right;
    
    protected List<string> possibleTargets;

 //   private PickupType _pickupType = PickupType.Regular;
    
    public bool canShoot = true;
    protected float _shootDelay = 1.0f;
    
    protected Ammo _currentAmmo;
    
    

    private void Start()
    {
        ChangeWeapon(PickupType.Regular);
        WeaponPickup.OnPickupPicked += ChangeWeapon;
        WeaponUIHandler.OnOutOfAmmo += ChangeWeapon;
    }
    
    protected void ChangeWeapon(PickupType pickupType)
    {
        if(_currentAmmo != null)
            _currentAmmo.DestroyThisComponent();
        
        switch (pickupType)
        {
            case PickupType.Shatter:
                _currentAmmo = gameObject.AddComponent<Ammo_Shatter>();
                _shootDelay = 1.6f;
                break;
            
            case PickupType.ShotGun:
                _currentAmmo = gameObject.AddComponent<Ammo_Shotgun>();
                _shootDelay = 1.5f;
                break;
            
            case PickupType.Regular:
                _currentAmmo = gameObject.AddComponent<Ammo_Regular>();
                _shootDelay = 2f;
                break;
        }

        _currentAmmo.bulletPrefab = bulletPrefab;
    //    _currentAmmo.possibleTargets = possibleTargets;
    //    _pickupType = pickupType;
    }


    void Update()
    {
        if (Input.GetButtonDown(fireButtonName) && canShoot)
        {
            _currentAmmo.TryShoot(transform.TransformPoint(transform.localPosition));
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_shootDelay);
        canShoot = true;
    }
}
