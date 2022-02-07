using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScriptAA : MonoBehaviour
{
    private Rigidbody bombRb;
    [SerializeField] private float bombSpeed = 30000000f;
    [SerializeField] private float rangeOfWeapon = 2f;
    

    void Start()
    {
        bombRb = FindObjectOfType<Rigidbody>();
        bombRb.velocity = transform.right * bombSpeed;
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
