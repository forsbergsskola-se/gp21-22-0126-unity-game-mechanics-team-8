using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Shotgun : Ammo
{
    
    public Ammo_Shotgun()
    {
        CountAmmo = true;
        shootDelay = 1.5f;
        AmmoAmount = 12;
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
    
    protected override IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        _canShoot = true;
    }
    
    
    protected override void Shoot(Vector3 position)
    {
        Vector3 addVector = new Vector3(0, -0.8f, 0);
        for (int i = 0; i < 5; i++)
        {
            addVector += new Vector3(0, 0.2f, 0);
            MakeBullet(position,forwardVector, baseDamage / 3, addVector, 0.5f);
        }
    }
}
