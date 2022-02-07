using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot_Enemy : Shoot
{
    [SerializeField] private PickupType pickupType = PickupType.Regular;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float shootDelay = 5.0f;
    
    protected override void StartupMethod()
    {
        ChangeWeapon(pickupType);
        possibleTargets = new List<string>() {"Player", "Ground"};
        canShoot = true;
    }

    public void Attack()
    {
        if (canShoot)
        {
            var pos = transform.InverseTransformPoint(transform.position);
            
            _currentAmmo.TryShoot(transform.TransformPoint(transform.localPosition), transform.right);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }
    
    
    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
    
}
