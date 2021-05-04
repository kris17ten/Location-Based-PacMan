using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatchMe : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        

        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        //update location
        agent.destination = player.transform.position;
    }
}
