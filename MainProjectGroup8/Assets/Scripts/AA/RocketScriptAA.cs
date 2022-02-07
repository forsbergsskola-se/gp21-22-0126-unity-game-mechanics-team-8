using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketScriptAA : MonoBehaviour
{
    public Transform playerPosition;
    [SerializeField] private float rangeOfWeapon = 5f;
    private Rigidbody rocketRb;
    

    void Start()
    {
        rocketRb = FindObjectOfType<Rigidbody>();
        //bombRb.velocity = -transform.up * bombSpeed;
        
    }
    
    void Update()
    {
        var randomForceMultiplier = Random.Range(0.5f, 2f);
        rocketRb.velocity += (Vector3.right * .02f * randomForceMultiplier);
        // Destroying the bullet after rangeOfWeapon in seconds
        Invoke(nameof(DestroyBomb), rangeOfWeapon);
        
    }
    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
