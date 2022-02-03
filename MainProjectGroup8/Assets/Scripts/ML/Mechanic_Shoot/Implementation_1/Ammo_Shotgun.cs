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
    
    protected override void Shoot(Vector3 position, Vector3 travelVector = new Vector3())
    {
        int numberPellets = 5;
        Vector3 addVector = new Vector3(0, -0.8f, 0);
        for (int i = 0; i < numberPellets; i++)
        {
            addVector += new Vector3(0, 0.2f, 0);
            MakeBullet(position,ForwardVector, baseDamage / 3, addVector, 0.5f, baseBulletSpeed * 0.8f);
        }
    }
}
