using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthUIHandler : MonoBehaviour
{
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite HalfHeart;
    [SerializeField] private Sprite EmptyHeart;
    
    
    void Start()
    {
        Damage.OnPlayerTakesDamage += TakeDamage;
    }


    private void TakeDamage(float damageAmount)
    {
        var hearts = gameObject.GetComponentsInChildren<Sprite>().ToList();
        int realDamage = 0;
        Sprite tempSprite;
        
        if (damageAmount > 5)
            realDamage = 1;
        if (damageAmount > 10)
            realDamage = 2;
        if (damageAmount > 15)
            realDamage = 3;
        
        for (int i = 2; i >= 0; i--)
        {
            tempSprite = hearts[i];
            if (hearts[i] == FullHeart)
            {
                if (realDamage > 1)
                {
                    tempSprite = EmptyHeart;
                    hearts[i] = EmptyHeart;
                }
                else if(realDamage == 1)
                {
                    tempSprite = HalfHeart;
                    hearts[i] = HalfHeart;
                }
            }
        }

        if (CheckIfDead())
        {
            
        }
    }


    private bool CheckIfDead()
    {
        var hearts = gameObject.GetComponentsInChildren<Sprite>().ToList();
        int emptyCount = 0;
        for (int i = 0; i < hearts.Count; i++)
        {
            if (hearts[i] == EmptyHeart)
                emptyCount++;
        }

        if (emptyCount == 3)
            return true;

        return false;
    }

}
