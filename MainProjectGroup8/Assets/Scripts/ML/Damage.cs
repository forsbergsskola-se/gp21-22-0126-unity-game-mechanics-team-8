using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


   private void Start()
   {
       HealthUIHandler.OnPlayerDies += PlayerDies;
   }

   private void OnDisable()
   {
       HealthUIHandler.OnPlayerDies -= PlayerDies;
   }

   public void TakeDamage(float damageAmount)
   {
       if (!gameObject.activeInHierarchy) return;
       SetDamageMaterial();

       switch (characterType)
       {
           case CharacterType.Enemy:
               baseHealth -= damageAmount;
               break;
           case CharacterType.Player:
           {
               if (OnPlayerTakesDamage != null)
                   OnPlayerTakesDamage(damageAmount);
               break;
           }
       }

       if (baseHealth <= 0)
       {
           Destroy(gameObject);
       }
       if (gameObject.activeSelf) 
           StartCoroutine(DelayMaterialSwap());
   }


   private void PlayerDies()
   {
       if(characterType == CharacterType.Player)
           gameObject.SetActive(false);
   }

   private void SetDamageMaterial()
   {
       if(_originalMat == null)
           _originalMat = GetComponent<Renderer>().material;
       
       GetComponent<Renderer>().material = damageMaterial;
   }

   IEnumerator DelayMaterialSwap()
   {
       yield return new WaitForSeconds(0.3f);
       GetComponent<Renderer>().material = _originalMat;
   }
}
