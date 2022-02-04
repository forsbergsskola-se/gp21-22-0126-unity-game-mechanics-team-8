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
        Debug.Log("bullet made");
        MakeBullet(position, travelVector != Vector3.zero ? travelVector : ForwardVector);
    }
}
