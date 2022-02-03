using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Regular : Ammo
{
    public Ammo_Regular()
    {
        CountAmmo = false;
        shootDelay = 1f;
    }

    
    public override void  TryShoot(Vector3 position)
    {
        if (_canShoot)
        {
            Shoot(position);
            ShotFired();
            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }
    
    protected override void Shoot(Vector3 position)
    {
        MakeBullet(position, forwardVector);
    }
    
    protected override IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        _canShoot = true;
    }
    

}
