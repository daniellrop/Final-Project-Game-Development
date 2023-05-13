using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FSM : MonoBehaviour
{
   
    [SerializeField] Transform[] AllPositions;
    [SerializeField] UnityEngine.AI.NavMeshAgent enemy; 

    int i = 0;

    void Start()
    {
        transform.GetChild(UnityEngine.Random.Range(1, 7)).gameObject.SetActive(true);
    }

    States enemyFState = States.Route;
    [SerializeField] Transform playerShip;
    [SerializeField] float distance;


    void Update()
    {

        var d = UnityEngine.Vector3.Distance(enemy.transform.position, playerShip.position);



        if (d < distance)
        {
            enemyFState = States.ChasePlayer;

        }

        else
        {
            enemyFState = States.Route;

        }




        if (enemyFState == States.ChasePlayer)
        {

            enemy.SetDestination(playerShip.parent.position);
        }

       
        if (enemyFState == States.Route)
        {
            enemy.SetDestination(AllPositions[i].position);

                if (!enemy.pathPending)
                if (enemy.remainingDistance <= enemy.stoppingDistance)                
                    if (!enemy.hasPath || enemy.velocity.sqrMagnitude == 0f)
                    {
                        i++;
                        if (i >= AllPositions.Length) i = 0;
                 
                    }
                
            


           
        }
      

       
    }


  

    

   

  

}