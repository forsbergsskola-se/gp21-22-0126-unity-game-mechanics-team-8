using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScriptAA : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float bombSpeed = 30f;
    [SerializeField] private float rangeOfWeapon = 5f;
    private Rigidbody bombRb;
    

    void Start()
    {
        bombRb = FindObjectOfType<Rigidbody>();
        //bombRb.velocity = -transform.up * bombSpeed;
        var randomForceMultiplier = Random.Range(0.8f, 1.5f);
        if(bombRb.velocity.y < 0)
            bombRb.AddForce(playerPosition.position * 2f * randomForceMultiplier);
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

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
