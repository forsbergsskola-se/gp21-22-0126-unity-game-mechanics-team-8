using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SplineMesh;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIHandler : MonoBehaviour
{
    private enum HeartSetType
    {
        Full, Half, Empty, WrongType
    }
    
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite HalfHeart;
    [SerializeField] private Sprite EmptyHeart;
    private float accumulatedDamage = 0;
    
    void Start()
    {
        Damage.OnPlayerTakesDamage += TakeDamage;
    }

    private void TakeDamage(float damageAmount)
    {

        accumulatedDamage += damageAmount;

        if (accumulatedDamage >= 20)
        {
            DoOnePointOfDamage();
            accumulatedDamage = 0;
        }

        if (CheckIfDead())
        {
            
        }
    }
    
    private HeartSetType GetHeartTypeAtIndex(int index)
    {
        var heart = gameObject.GetComponentsInChildren<Image>().ToList()[index];

        if (heart.sprite == FullHeart)
            return HeartSetType.Full;
        
        if (heart.sprite == HalfHeart)
            return HeartSetType.Half;
        
        return heart.sprite == EmptyHeart ? HeartSetType.Empty : HeartSetType.WrongType;
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
    }
    
    private bool CheckIfDead()
    {
        for (var i = 0; i < 3; i++)
        {
            if (GetHeartTypeAtIndex(i) != HeartSetType.Empty)
            {
                return false;
            }
        }
        return true;
    }

}
