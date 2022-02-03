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
    
    private PickupType _pickupType = PickupType.Regular;
    
    public bool _canShoot = true;
    protected float shootDelay = 1.0f;
    
    private Ammo currentAmmo;
    

    private void Start()
    {
        ChangeWeapon(PickupType.Regular);
        WeaponPickup.OnPickupPicked += ChangeWeapon;
        WeaponUIHandler.OnOutOfAmmo += ChangeWeapon;
    }
    
    private void ChangeWeapon(PickupType pickupType)
    {
        if(currentAmmo != null)
            currentAmmo.DestroyThisComponent();
        
        switch (pickupType)
        {
            case PickupType.Shatter:
                currentAmmo = gameObject.AddComponent<Ammo_Shatter>();
                shootDelay = 1.6f;
                break;
            
            case PickupType.ShotGun:
                currentAmmo = gameObject.AddComponent<Ammo_Shotgun>();
                shootDelay = 1.5f;
                break;
            
            case PickupType.Regular:
                currentAmmo = gameObject.AddComponent<Ammo_Regular>();
                shootDelay = 0.6f;
                break;
        }

        currentAmmo.bulletPrefab = bulletPrefab;
        currentAmmo.possibleTargets = possibleTargets;
        _pickupType = pickupType;
    }


    void Update()
    {
        if (Input.GetButtonDown(fireButtonName) && _canShoot)
        {
            currentAmmo.TryShoot(transform.TransformPoint(transform.localPosition));
            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        Debug.Log(_canShoot);
        yield return new WaitForSeconds(shootDelay);
        _canShoot = true;
    }
}