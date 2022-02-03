using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Shotgun : Ammo
{
    
    public Ammo_Shotgun()
    {
        CountAmmo = true;
        AmmoAmount = 12;
    }
    
    public override void  TryShoot(Vector3 position)
    {
        Shoot(position);
        ShotFired();
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
