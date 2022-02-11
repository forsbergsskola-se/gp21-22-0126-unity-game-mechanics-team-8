using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private Vector3Value playerPosition;
    
    void Update()
    {
        playerPosition.Vector3 = transform.position;
    }
}
