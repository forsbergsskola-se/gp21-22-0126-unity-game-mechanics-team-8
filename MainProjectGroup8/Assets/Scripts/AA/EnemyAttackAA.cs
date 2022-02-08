using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAA : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject rocketRPrefab;
    public GameObject rocketLPrefab;
    public Transform bombExitPoint;
    public Transform rocketRExitPoint;
    public Transform rocketLExitPoint;
    //[SerializeField] private float timeBetweenAttacks = 2f;
    [SerializeField] private float instantiationTimer = 2f;
    private EnemyMoveAA _enemyMoveAA;

    private void Start()
    {
        _enemyMoveAA = FindObjectOfType<EnemyMoveAA>();
    }

    void Update()
    {
        if (_enemyMoveAA.playerInAttackRange)
        {
            DropBomb();
            RocketLauncherLeft();
            RocketLauncherRight();
        }
    }

    private void RocketLauncherRight()
    {
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            Instantiate(rocketRPrefab, rocketRExitPoint.position, rocketRExitPoint.rotation);
            instantiationTimer = 2f;
        }
    }

    private void RocketLauncherLeft()
    {
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            Instantiate(rocketLPrefab, rocketLExitPoint.position, rocketLExitPoint.rotation);
            instantiationTimer = 2f;
        }
    }

    private void DropBomb()
    { 
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            Instantiate(bombPrefab, bombExitPoint.position, bombExitPoint.rotation);
            instantiationTimer = 2f;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
            Destroy(col.gameObject);
    }
}
