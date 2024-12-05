using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeAI : MonoBehaviour
{
    private Transform player;
    private float sightRange = 8f;
    private bool playerInRange;
    public LayerMask whatIsPlayer;
   
    // Start is called before the first frame update
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (playerInRange) {
            transform.LookAt(player);
        }

    }
}
