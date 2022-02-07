using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScriptAA : MonoBehaviour
{
    private Rigidbody bombRb;
    [SerializeField] private float bombSpeed = 30f;
    [SerializeField] private float rangeOfWeapon = 5f;
    

    void Start()
    {
        bombRb = FindObjectOfType<Rigidbody>();
        bombRb.velocity = -transform.up * bombSpeed;
    }
    
    void Update()
    {
        // Destroying the bullet after rangeOfWeapon in seconds
        Invoke(nameof(DestroyBomb), rangeOfWeapon);
        
    }
    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
    void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
