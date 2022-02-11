using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAA : MonoBehaviour
{
    [SerializeField] private Vector3Value playerPosition;
    [SerializeField] private float rangeOfWeapon = 5f;
    private Rigidbody rocketRb;
    

    void Start()
    {
        rocketRb = FindObjectOfType<Rigidbody>();

    }
    
    void LateUpdate()
    {
        Vector3 dir = (playerPosition.Vector3 - transform.position).normalized;
        Vector3 deltaPosition = 50 * dir * Time.deltaTime;
        rocketRb.MovePosition(transform.position + deltaPosition);
        
        Invoke(nameof(DestroyBomb), rangeOfWeapon);
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
            Destroy(col.gameObject);
        Destroy(gameObject);
    }

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
