using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SplineMesh;
using UnityEngine;

public enum HeartSetType
{
    Full, Half, Empty
}

public class HealthUIHandler : MonoBehaviour
{
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite HalfHeart;
    [SerializeField] private Sprite EmptyHeart;
    private List<Sprite> _spriteList;

    void Start()
    {
        _spriteList = gameObject.GetComponentsInChildren<Sprite>().ToList();
        
        Damage.OnPlayerTakesDamage += TakeDamage;
    }


    private void GetHeartFromList(out Sprite heartSprite, int index)
    {
        heartSprite = gameObject.GetComponentsInChildren<Sprite>().ToList()[index];
    }

    private void SetSpriteByType(HeartSetType heartSetType, int indexToSet)
    {
        
    }
    

    private void TakeDamage(float damageAmount)
    {
        var hearts = gameObject.GetComponentsInChildren<Sprite>().ToList();
        
    //    hearts.Where(x => x.)
        
        int realDamage = 0;
        Sprite tempSprite;
        
        if (damageAmount > 5)
            realDamage = 1;
        if (damageAmount > 10)
            realDamage = 2;
        if (damageAmount > 15)
            realDamage = 3;

        if (realDamage >= 1)
        {
           var  d = hearts.Where(x => x == FullHeart).Select(x => x = HalfHeart).ToList();
        //   d = HalfHeart;

        }

        if (realDamage >= 1 && realDamage < 3)
        {
 //           hearts.Where(x => x == HalfHeart)
        }



        for (int i = 2; i >= 0; i--)
        {
            GetHeartFromList(out tempSprite,i);

            if (tempSprite == FullHeart)
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
