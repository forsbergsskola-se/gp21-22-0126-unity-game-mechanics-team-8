using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
     Enemy, Player, Object
}

public class Damage : MonoBehaviour
{
   [SerializeField] float baseHealth = 40;
   [SerializeField] private Material damageMaterial;
   [SerializeField] private CharacterType characterType;
   private Material _originalMat;
   
   public delegate void TakeDamageDelegate(float damageAmount);
   public static event TakeDamageDelegate OnPlayerTakesDamage;
   
   public void TakeDamage(float damageAmount)
   {
       Debug.Log("player takes damage");
       if(_originalMat == null)
            _originalMat = GetComponent<Renderer>().material;
       
       GetComponent<Renderer>().material = damageMaterial;
       
       if(characterType == CharacterType.Enemy)
           baseHealth -= damageAmount;
       
       else if(characterType == CharacterType.Player)
       {
           if (OnPlayerTakesDamage != null)
               OnPlayerTakesDamage(damageAmount);
       }

       if (baseHealth <= 0)
       {
           Destroy(gameObject);
       }

       StartCoroutine(DelayMaterialSwap());
   }


   IEnumerator DelayMaterialSwap()
   {
       yield return new WaitForSeconds(0.2f);
       GetComponent<Renderer>().material = _originalMat;
   }
}
