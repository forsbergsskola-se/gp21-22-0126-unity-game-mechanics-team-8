using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class DestroyAfterlifeTimeJJ : MonoBehaviour
{
     [SerializeField]
     private float lifeTime = 0.5f;

     
     
     
     private void OnCollisionEnter(Collision collision)
     {
          if (collision.gameObject.CompareTag("Player"))
          {
               // StartCoroutine(DestroyAfterLifeTime(lifeTime));
               Destroy(gameObject);

          }
     }

     IEnumerator DestroyAfterLifeTime(float lifeTime)
     {
          yield return new WaitForSeconds(lifeTime);
          Destroy(gameObject);
     }
}
