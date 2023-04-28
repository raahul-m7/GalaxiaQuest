using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : MonoBehaviour
{
    public Transform player;
    public GameObject Ship;
    public float TimeLimit = 7f;
    float timeElapsed = 0f; 
    bool boxUp = false;
    public float Range;
    
    void Start()
    {
        Ship.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer < Range)
        {
            if (timeElapsed > TimeLimit)
            {
                if(Ship.GetComponent<BoxCollider>().enabled == false)
                {
                    Ship.GetComponent<BoxCollider>().enabled = true;
                    boxUp = true;
                    timeElapsed = 0;
                }
            }
            else
            {
                timeElapsed += Time.deltaTime;
            }
        }
    }
}

