using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAA : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombExitPoint;
    [SerializeField] private float timeBetweenAttacks = 2f;
    private EnemyMoveAA _enemyMoveAA;

    private void Start()
    {
        _enemyMoveAA = FindObjectOfType<EnemyMoveAA>();
    }

    void Update()
    {
        if (_enemyMoveAA.playerInAttackRange)
        {
            Invoke(nameof(DropBomb), timeBetweenAttacks);
        }
    }

    private void DropBomb()
    {
        Instantiate(bombPrefab, bombExitPoint.position, bombExitPoint.rotation);
    }
}
