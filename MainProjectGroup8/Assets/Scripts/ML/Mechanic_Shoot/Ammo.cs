using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<string> possibleTargets;
    protected Vector3 forwardVector = Vector3.right;
    
    protected float baseBulletSpeed = 10f;
    protected float baseDamage = 10f;
    protected bool CountAmmo = false;
    protected int AmmoAmount = 0;
    

    public delegate void ShotFiredDelegate();
    public static event ShotFiredDelegate OnShotFired;

    
    protected abstract void Shoot(Vector3 position);
    
    public void  TryShoot(Vector3 position)
    {
        Shoot(position);
        ShotFired();
    }
    
    
    public void DestroyThisComponent()
    {
        Destroy(this);
    }

    protected void ShotFired()
    {
        if (OnShotFired != null)
            OnShotFired();
    }


    protected void MakeBullet(Vector3 bulletPos, Vector3 travelVector , float damageAmount = 10, Vector3 addVector =  new Vector3(), float bulletScale = 1, float moveSpeed = 10.0f, bool returnHitLocation = false)
    {
        var tempBullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
        tempBullet.GetComponent<Bullet>().travelVector = travelVector + addVector;
        tempBullet.GetComponent<Bullet>().damageAmount = damageAmount;
        tempBullet.GetComponent<Bullet>().returnHitLocation = returnHitLocation;
        tempBullet.GetComponent<Bullet>().moveSpeed = moveSpeed;
        tempBullet.GetComponent<Bullet>().possibleTargets = possibleTargets;
        tempBullet.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f) * bulletScale;
    }
}
