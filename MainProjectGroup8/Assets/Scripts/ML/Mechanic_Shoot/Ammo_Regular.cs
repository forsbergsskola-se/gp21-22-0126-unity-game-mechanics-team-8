using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Regular : Ammo
{
    public Ammo_Regular()
    {
        CountAmmo = false;
    }

    public override void  TryShoot(Vector3 position)
    {
        Shoot(position);
        ShotFired();
    }
    
    protected override void Shoot(Vector3 position)
    {
        MakeBullet(position, forwardVector);
    }
    
}
