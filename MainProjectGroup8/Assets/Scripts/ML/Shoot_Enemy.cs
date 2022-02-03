using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Enemy : Shoot
{
    [SerializeField] private PickupType _pickupType = PickupType.Regular;


    void Start()
    {
        ChangeWeapon(_pickupType);
        
        possibleTargets = new List<string>() {"Player", "Ground"};
    }

    public void Attack()
    {
        if (canShoot)
        {
            _currentAmmo.TryShoot(transform.TransformPoint(transform.localPosition), new Vector3(-1,0,0));
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
