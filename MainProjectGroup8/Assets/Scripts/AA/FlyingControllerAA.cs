using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    [SerializeField] private float staminaDrain = 0.4f;
    [SerializeField] private float staminaReloadTime = 2f;
    [SerializeField] private float staminaReloadRate = 30f;
    private Coroutine _regen;
    private bool _canFly;
    private float maxStamina = 100;
    private float _currentStamina;
    private readonly WaitForSeconds _regenTick = new WaitForSeconds(0.1f);

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        _currentStamina = maxStamina;
        _canFly = true;
    }


    private void Update()
    {
        if (playerInputController.FlyingInput && _canFly)
        {
            myRigidbody.AddForce(Vector3.up * flyForce);
            UseStamina(staminaDrain);
        }
    }
    
    private void UseStamina(float amountOfStaminaDrained)
    {
        if (_currentStamina - amountOfStaminaDrained >= 0)
        {
            _currentStamina -= amountOfStaminaDrained;

            if (_regen != null)
            {
                StopCoroutine(_regen);
            }

            _regen = StartCoroutine(RegenStamina());
        }
        else
        {
            _canFly = false;
        }
    }
    
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(staminaReloadTime);
        while (_currentStamina < maxStamina)
        {
            _currentStamina += maxStamina / staminaReloadRate;
            _canFly = true;
            yield return _regenTick;
        }
        _regen = null;
    }
}

