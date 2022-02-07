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

    public delegate void ReturnHitLocationDelegate(Vector3 hitLocation);
    public static event ReturnHitLocationDelegate OnReturnHitLocation;
    
    void Start()
    {
        StartCoroutine(DelayDestroy());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        for (int i = 0; i < possibleTargets.Count; i++)
        {
            if (other.gameObject.CompareTag(possibleTargets[i]))
            {
                Debug.Log("collider is acceptable target");
                if (other.gameObject.GetComponent<Damage>())
                {

                    Debug.Log("enemy has damage component");
                    other.gameObject.GetComponent<Damage>().TakeDamage(damageAmount);
                }

                if (returnHitLocation && OnReturnHitLocation != null)
                    OnReturnHitLocation(transform.position);
            }
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
