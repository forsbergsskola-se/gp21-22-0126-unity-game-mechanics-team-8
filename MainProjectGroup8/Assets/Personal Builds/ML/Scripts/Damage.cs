using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
   [SerializeField] int baseHealth = 40;
   [SerializeField] private Material damageMaterial;


   public void DoDamage(int damageAmount)
   {
       baseHealth -= damageAmount;
   //    GetComponent<Renderer>().material = damageMaterial;

       if (baseHealth <= 0)
       {
           Destroy(gameObject);
       }
   }

}
