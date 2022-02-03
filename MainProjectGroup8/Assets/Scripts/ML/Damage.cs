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


   public void DoDamage(float damageAmount)
   {
       if(_originalMat == null)
            _originalMat = GetComponent<Renderer>().material;
       baseHealth -= damageAmount;
       GetComponent<Renderer>().material = damageMaterial;
       
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
