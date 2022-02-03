using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    protected float shootDelay = 1.0f;
    protected bool countAmmo = false;
    [SerializeField] private int ammoAmount = 0;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private List<string> possibleTargets;


    protected abstract void Shoot();

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

    private void Update()
    {
        
    }
}
