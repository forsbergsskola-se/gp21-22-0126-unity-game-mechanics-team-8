using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot_Enemy : Shoot
{
    [SerializeField] private PickupType _pickupType = PickupType.Regular;
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        ChangeWeapon(_pickupType);
        
        possibleTargets = new List<string>() {"Player", "Ground"};
    }

    public void Attack()
    {
        if (canShoot)
        {
            _currentAmmo.TryShoot(transform.TransformPoint(transform.localPosition), transform.right);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    private void FixedUpdate()
    {
        var dot = Vector3.Dot(playerTransform.forward, transform.forward);
        Debug.Log(dot);
    //    Debug.Log(Vector3.Distance(playerTransform.position, transform.position));

        if (dot < 0 && Vector3.Distance(playerTransform.position, transform.position) < 8)
        {
            Attack();
        }
    }


    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(4);
        canShoot = true;
    }
    
}
