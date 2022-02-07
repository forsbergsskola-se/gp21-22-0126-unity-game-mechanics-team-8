using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAA : EnemiesAA
{

    //variables
    [SerializeField] private int _moveSpeed;
    [SerializeField] private int _attackDamage;
    [SerializeField] private  int _lifePoints;
    [SerializeField] private float _attackRadius;
   

    //movement
    public float _followRadius;
    //end
    [SerializeField] Transform playerTransform;
    //Attack check
    public bool playerInAttackRange;

    void Start()
    {
      //get the player transform   
      playerTransform = FindObjectOfType<PlayerWalkController>().GetComponent<Transform>();
      //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setLifePoints(_lifePoints);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkFollowRadius(playerTransform.position.x,transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    playerInAttackRange = true;

                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //walk
                    playerInAttackRange = false;
                }

            }
            //if player is behind enemies
            else if(playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    playerInAttackRange = true;
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    
                    playerInAttackRange = false;
                }
            }
        }
    }
}
