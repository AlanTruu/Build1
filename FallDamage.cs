using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public LayerMask groundLayer;
    public int delay = 10;
    public float startTimer;
    public bool timerHasBegun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, -transform.up, 1.5f, groundLayer) && !timerHasBegun) {
            startTimer = Time.time;
            timerHasBegun = true;
        }
        
        //Constantly check if player is off the ground for 10 seconds
        if (!Physics.Raycast(transform.position, -transform.up, 1.5f, groundLayer) && timerHasBegun) {
            if (Time.time > startTimer + delay) {
                GetComponent<Life>().damage(10);
            }
        }
        else if (Physics.Raycast(transform.position, -transform.up, 1.5f, groundLayer)) {
            timerHasBegun = false;
        } 
    }
}
