using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipJetPackScriptAA : MonoBehaviour
{
    [SerializeField] private BooleanValue jetPackIsOn;
    
    private void OnTriggerEnter(Collider other)
    {
        jetPackIsOn.BoolValue = true;
        gameObject.SetActive(false);
    }
}
