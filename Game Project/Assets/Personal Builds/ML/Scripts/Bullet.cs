using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 5.0f;
    public Vector3 travelVector;
    public float moveSpeed = 10.0f;


 //   public delegate void CauseDamageDelegate();

 //   public static event CauseDamageDelegate OnBulletDamage;
    
    void Start()
    {
        StartCoroutine(DelayDestroy());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Do thing Here
        }
        Destroy(gameObject);
    }
    

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }
    
    
    void Update()
    {
        transform.position += travelVector * moveSpeed * Time.deltaTime;
    }
}
