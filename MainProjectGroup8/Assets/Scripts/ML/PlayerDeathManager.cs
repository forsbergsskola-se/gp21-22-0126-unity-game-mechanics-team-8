using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    
    [SerializeField] private Canvas GameOverUI;
    private Canvas holdGameOverUI;
    
    void Start()
    {
        HealthUIHandler.OnPlayerDies += PlayerDies;

        holdGameOverUI = Instantiate(GameOverUI);
        holdGameOverUI.enabled = false;
    }

    private void OnDisable()
    {
        HealthUIHandler.OnPlayerDies -= PlayerDies;
    }

    private void PlayerDies()
    {
        holdGameOverUI.enabled = true;
    }
}
