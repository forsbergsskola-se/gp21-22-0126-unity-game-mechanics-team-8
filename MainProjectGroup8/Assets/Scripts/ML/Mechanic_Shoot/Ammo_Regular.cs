using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Regular : Ammo
{
    public Ammo_Regular()
    {
        CountAmmo = false;
    }
    
    protected override void Shoot(Vector3 position, Vector3 travelVector = new Vector3())
    {
        MakeBullet(position, travelVector != Vector3.zero ? travelVector : ForwardVector, baseDamage, Vector3.zero, 2.0f, baseBulletSpeed);
    }
}
