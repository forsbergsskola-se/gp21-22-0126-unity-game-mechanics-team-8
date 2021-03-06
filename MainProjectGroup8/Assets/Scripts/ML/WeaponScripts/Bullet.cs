using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] List<string> possibleTargets;
    public float lifeSpan = 8.0f;
    public Vector3 travelVector;
    public float moveSpeed = 14.0f;
    public float damageAmount = 10;
    public bool returnHitLocation;

    public delegate void ReturnHitLocationDelegate(Vector3 hitLocation, Vector3 travelVector);
    public static event ReturnHitLocationDelegate OnReturnHitLocation;
    
    void Start()
    {
        StartCoroutine(DelayDestroy());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.activeInHierarchy)
        {
            for (int i = 0; i < possibleTargets.Count; i++)
            {
                if (other.gameObject.CompareTag(possibleTargets[i]))
                {
                    if (other.gameObject.GetComponent<Damage>())
                    {
                        other.gameObject.GetComponent<Damage>().TakeDamage(damageAmount);
                    }

                    if (returnHitLocation && OnReturnHitLocation != null)
                    {
                        OnReturnHitLocation(transform.position, gameObject.transform.right);
                    }
                }
            }
            Destroy(gameObject);
        }
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
