using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SplineMesh;
using UnityEngine;
using UnityEngine.UI;

public enum HeartSetType
{
    Full, Half, Empty, WrongType
}

public class HealthUIHandler : MonoBehaviour
{
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite HalfHeart;
    [SerializeField] private Sprite EmptyHeart;
    
    void Start()
    {
        Damage.OnPlayerTakesDamage += TakeDamage;
    }

        
 
    private void SetSpriteByType(HeartSetType heartSetType, int indexToSet)
    {
        
    }
    

    private void TakeDamage(float damageAmount)
    {
        int totalDamage = 0;

         totalDamage = (int)Mathf.Floor(damageAmount / 5);

         DoOnePointOfDamage(); 
         
         for (int i = 0; i < totalDamage; i++)
         {
             //    DoOnePointOfDamage(); 
         }
        
        
        if (CheckIfDead())
        {
            
        }
    }

    private bool SetHalfHeartToEmpty(out Image heart)
    {
        heart = gameObject.GetComponentsInChildren<Image>()
            .SingleOrDefault(x => x.sprite == HalfHeart);

        return heart != null;
    }


    private HeartSetType GetHeartTypeAtIndex(int index)
    {
        var heart = gameObject.GetComponentsInChildren<Image>().ToList()[index];

        if (heart.sprite == FullHeart)
            return HeartSetType.Full;
        
        if (heart.sprite == HalfHeart)
            return HeartSetType.Half;
        
        if (heart.sprite == EmptyHeart)
            return HeartSetType.Empty;

        return HeartSetType.WrongType;
    }
    
    private void SetHeartContainer(int index, HeartSetType imageType)
    {
        var tempHearts = gameObject.GetComponentsInChildren<Image>().ToList();

        tempHearts[index].sprite = imageType switch
        {
            HeartSetType.Empty => EmptyHeart,
            HeartSetType.Half => HalfHeart,
            HeartSetType.Full => FullHeart,
            _ => tempHearts[index].sprite
        };
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

        for (int i = 2; i >= 0; i--)
        {
            var type = GetHeartTypeAtIndex(i);

            if (type == HeartSetType.Half && amountDamageTaken < 1)
            {
                SetHeartContainer(i, HeartSetType.Empty);
                amountDamageTaken++;
            }
            else if (type == HeartSetType.Full && amountDamageTaken < 1)
            {
                SetHeartContainer(i, HeartSetType.Half);
                amountDamageTaken++;
            }
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
