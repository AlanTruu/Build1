using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinAI : MonoBehaviour
{
    public float followingRange = 7f;
    private bool inRange;
    private NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsPlayer;
    
    public void follow() {
        agent.SetDestination(player.position);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(transform.position, followingRange, whatIsPlayer);
        if (inRange) {
            follow();
        }
    }
}
