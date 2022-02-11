using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeTwoAttackAA : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform exitPoint;
    public GameObject player;
    //[SerializeField] private float timeBetweenAttacks = 2f;
    [SerializeField] private float instantiationTimer = 1f;
    private EnemyMoveAA _enemyMoveAA;
    private Vector3 direction;

    private void Start()
    {
        _enemyMoveAA = FindObjectOfType<EnemyMoveAA>();
    }

    void Update()
    {
        if (player != null)
        {
            var heading = this.transform.position - player.transform.position;
            var distance = heading.magnitude;
            direction = heading / distance;
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward - direction);
        }
        
        if (_enemyMoveAA.playerInAttackRange)
        {
            MissileLauncher();
        }
    }

    private void MissileLauncher()
    {
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            Instantiate(missilePrefab, exitPoint.position, Quaternion.FromToRotation(Vector3.up, transform.forward - direction));
            instantiationTimer = 1f;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
            Destroy(col.gameObject);
    }
}
