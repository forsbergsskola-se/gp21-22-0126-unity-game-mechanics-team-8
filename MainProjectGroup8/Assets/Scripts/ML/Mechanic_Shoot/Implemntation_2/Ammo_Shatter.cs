using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Shatter : Ammo
{
    private void Start()
    {
        Bullet.OnReturnHitLocation += ShatterPattern;
    }

    private void OnDisable()
    {
        Bullet.OnReturnHitLocation -= ShatterPattern;
    }

    public Ammo_Shatter()
    {
        CountAmmo = true;
        AmmoAmount = 10;
    }

    protected override void Shoot(Vector3 position,  Vector3 travelVector = new Vector3())
    {
        MakeBullet(position, travelVector, baseDamage * 1.4f, Vector3.zero, 1.5f, baseBulletSpeed / 2, true);
    }
    
    private void ShatterPattern(Vector3 shotLocation, Vector3 travelVector)
    {
        int numberPellets = 8;
        shotLocation += -travelVector * 2;
        Debug.Log("shatter pattern engaged");
        
        for (int i = 0; i < numberPellets; i++)
        {
            float angle = i * 360 / numberPellets;
            var xMod = MathF.Cos(angle * (Mathf.PI / 180.0f));
            var yMod  = MathF.Sin(angle * (Mathf.PI / 180.0f));
            Vector3 moveVec = new Vector3(1 * xMod, 1 * yMod);

            MakeBullet(shotLocation,moveVec, baseDamage / 3, Vector3.zero, 0.4f, baseBulletSpeed / 2);
        }
    }
}
