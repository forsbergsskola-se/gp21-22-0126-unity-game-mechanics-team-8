using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Player : Shoot
{
    [SerializeField] private string fireButtonName = "Fire1";
    
    private void Start()
    {
        ChangeWeapon(PickupType.Regular);
        WeaponPickup.OnPickupPicked += ChangeWeapon;
        WeaponUIHandler.OnOutOfAmmo += ChangeWeapon;

        possibleTargets = new List<string>() {"Enemy", "Ground"};
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