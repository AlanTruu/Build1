using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperateMailBox : MonoBehaviour
{
    [SerializeField] ParticleSystem confetti;
    private Transform player;
    private bool used;
    public void operate() {
        if (used == false) {
            confetti.gameObject.SetActive(true);
            player.GetComponent<Player>().score += 1;
            used = true;
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        confetti.gameObject.SetActive(false);
        player = GameObject.Find("Player").transform;
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
