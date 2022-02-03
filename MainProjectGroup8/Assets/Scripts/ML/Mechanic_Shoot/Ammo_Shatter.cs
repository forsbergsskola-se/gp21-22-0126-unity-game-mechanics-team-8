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

    public Ammo_Shatter()
    {
        CountAmmo = true;
        AmmoAmount = 10;
    }
    
    public override void  TryShoot(Vector3 position)
    {
        Shoot(position);
        ShotFired(); 
    }
    
    
    protected override void Shoot(Vector3 position)
    {
        MakeBullet(position, forwardVector, baseDamage * 1.4f, Vector3.zero, 1.5f, baseBulletSpeed / 2, true);
    }
    
    
    private void ShatterPattern(Vector3 shotLocation)
    {
        int numberPellets = 8;
        for (int i = 0; i < numberPellets; i++)
        {
            float angle = i * 360 / numberPellets;
            var xMod = MathF.Cos(angle * (Mathf.PI / 180.0f));
            var yMod  = MathF.Sin(angle * (Mathf.PI / 180.0f));
            Vector3 moveVec = new Vector3(1 * xMod, 1 * yMod);
            Debug.Log(moveVec.x);

            MakeBullet(shotLocation,moveVec, baseDamage / 3, Vector3.zero, 0.4f, baseBulletSpeed / 2);
        }
    }
    
}
