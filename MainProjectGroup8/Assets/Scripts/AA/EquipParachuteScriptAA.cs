using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipParachuteScriptAA : MonoBehaviour
{
    [SerializeField] private BooleanValue parachuteIsOn;
    
    private void OnTriggerEnter(Collider other)
    {
        parachuteIsOn.BoolValue = true;
        gameObject.SetActive(false);
    }
}
