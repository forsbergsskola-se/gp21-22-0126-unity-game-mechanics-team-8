using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Regular : Ammo
{
    public Ammo_Regular()
    {
        CountAmmo = false;
    }
    
    protected override void Shoot(Vector3 position)
    {
        MakeBullet(position, ForwardVector);
    }
}
