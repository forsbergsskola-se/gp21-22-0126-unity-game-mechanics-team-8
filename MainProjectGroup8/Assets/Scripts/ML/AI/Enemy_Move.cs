using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private Spline theSpline;
    private Vector3 testVector;
    private bool rotate = true;
    private bool move = false;
    private State currentState;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private float moveSpeed = 3.0f;
    
    void Start()
    {

        currentState = new Idle(playerTrans, gameObject);
        theSpline= GameObject.FindWithTag("Splines").GetComponent<Spline>();
        testVector = GetLocationAtSplinePoint(1);

    }


    private Vector3 GetLocationAtSplinePoint(int index)
    {
        Vector3 outVec = Vector3.zero;
        if (theSpline != null)
            if (theSpline.nodes.Count > index)
                outVec = theSpline.nodes[index].Position;    
        
        return outVec;
    }
    
    void Update()
    {

        currentState.Process();
        
        if (rotate)
        {
         //   RotateEnemy();
            rotate = false;
            move = true;
        }

        if (move)
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        
    }

    private void RotateEnemy()
    {
        transform.Rotate(new Vector3(0, 1, 0), 180);
    }
    
}
