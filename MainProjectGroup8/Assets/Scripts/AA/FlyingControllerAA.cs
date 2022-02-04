using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float flyForce = 100f;
    [SerializeField] private PlayerInputController playerInputController;
    [SerializeField] private float staminaDrain = 0.4f;
    [SerializeField] private float staminaReloadTime = 2f;
    [SerializeField] private float staminaReloadRate = 30f;
    [SerializeField] private float  maxStamina = 100;
    [SerializeField] private float gravityFallMultiplier = 2.5f;
    [SerializeField] private BooleanValue jetPackIsOn;
    [SerializeField] private Slider staminaBar;
    private Coroutine _regen;
    private bool _canFly;
    private float _currentStamina;
    private readonly WaitForSeconds _regenTick = new WaitForSeconds(0.1f);

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        _currentStamina = maxStamina;
        _canFly = true;
        
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }


    private void Update()
    {
        if (playerInputController.FlyingInput && _canFly && jetPackIsOn.BoolValue)
        {
            myRigidbody.AddForce(Vector3.up * flyForce);
            Discharge(staminaDrain);
        }
        
        // if (myRigidbody.velocity.y < 0 && !playerInputController.FlyingInput)
        // {
        //     myRigidbody.velocity += Vector3.up*Physics.gravity.y*(gravityFallMultiplier - 1)*Time.deltaTime;
        // }
        // else if (myRigidbody.velocity.y > 0 && !playerInputController.FlyingInput)
        // {
        //     myRigidbody.velocity += Vector3.up*Physics.gravity.y*(gravityFallMultiplier - 1)*Time.deltaTime;
        // }
    }
    
    private void Discharge(float amountOfStaminaDrained)
    {
        if (_currentStamina - amountOfStaminaDrained >= 0)
        {
            _currentStamina -= amountOfStaminaDrained;
            staminaBar.value = _currentStamina;

            if (_regen != null)
            {
                StopCoroutine(_regen);
            }

            _regen = StartCoroutine(Recharge());
        }
        else
        {
            _canFly = false;
        }
    }
    
    private IEnumerator Recharge()
    {
        yield return new WaitForSeconds(staminaReloadTime);
        while (_currentStamina < maxStamina)
        {
            _currentStamina += maxStamina / staminaReloadRate;
            _canFly = true;
            staminaBar.value = _currentStamina;
            yield return _regenTick;
        }
        _regen = null;
    }
}

