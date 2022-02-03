using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SplineMesh;
using UnityEngine;
using UnityEngine.UI;

public enum HeartSetType
{
    Full, Half, Empty
}

public class HealthUIHandler : MonoBehaviour
{
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite HalfHeart;
    [SerializeField] private Sprite EmptyHeart;
    private float totalDamage = 0;
    

    void Start()
    {
//        _spriteList = gameObject.GetComponentsInChildren<Sprite>().ToList();
        
        Damage.OnPlayerTakesDamage += TakeDamage;
    }

        
 
    private void SetSpriteByType(HeartSetType heartSetType, int indexToSet)
    {
        
    }
    

    private void TakeDamage(float damageAmount)
    {
        int totalDamage = 0;

         totalDamage = (int)Mathf.Floor(damageAmount / 5);

        
         
         for (int i = 0; i < totalDamage; i++)
         { 
         //    DoOnePointOfDamage(); 
         }
        
        
        if (CheckIfDead())
        {
            
        }
    }

    private bool GetHalfHeart(out Image heart)
    {
        heart = gameObject.GetComponentsInChildren<Image>()
            .SingleOrDefault(x => x.sprite == HalfHeart);

        return heart != null;
    }


    private void SetHeartContainer(int index, Sprite image)
    {
        var tempHearts = gameObject.GetComponentsInChildren<Image>().ToList();

        tempHearts[index].sprite = image;
    }

    private bool GetAllFullHeart(out List<Image> heart)
    {
        heart = new List<Image>();
        
        var  tempHearts = gameObject.GetComponentsInChildren<Image>()
            .Where(x => x.sprite == FullHeart).ToList();

        if (tempHearts.Count >= 1)
            return true;

        if (tempHearts.Count < 1)
            return false;


        return false;
    }

    private void DoOnePointOfDamage()
    {
        var amountDamageTaken = 0;
        
        if (GetHalfHeart(out Image tempImage))
        {
            tempImage.sprite = EmptyHeart;
            amountDamageTaken++;
        }

        if (amountDamageTaken >= 1) return;
        
        if (GetAllFullHeart(out List<Image> tempSpriteList))
        {
            if (tempSpriteList.Count >= 1)
                tempSpriteList[^1].sprite = HalfHeart;
        }

        CheckIfDead();
    }
    
    private bool CheckIfDead()
    {
        if (GetAllFullHeart(out List<Image> heart))
        {
            return false;
        }
        return true;
    }

}
