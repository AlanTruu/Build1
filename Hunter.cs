using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunter : MonoBehaviour
{
    private Transform player;
    public LayerMask whatIsPlayer;
    private bool isWatched;
    private bool playerInRange;
    private bool unobstructedView;
    private float killZone = 3f;
    public NavMeshAgent agent;
    private float patrolRadius = 100f;
    [SerializeField] private Camera mainCamera;
    
    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        isWatched = false;
        playerInRange = false;
        transform.rotation = Quaternion.identity;
    }
    
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, patrolRadius, whatIsPlayer);
        Vector3 viewPoint = mainCamera.WorldToViewportPoint(transform.position);
        
        
        if (viewPoint.x > 0 && viewPoint.x < 1 && viewPoint.y > 0 && viewPoint.y < 1 && viewPoint.z > 0) {
            isWatched = true;
        }
        else {
            isWatched = false;
        }
        
        
        if (playerInRange && !isWatched) {
            agent.SetDestination(player.position);
        }
        else if (playerInRange && isWatched) {
            Vector3 directionToPlayer = mainCamera.transform.position - transform.position;
            Ray ray = new Ray(transform.position, directionToPlayer.normalized);
            RaycastHit hit;
            Physics.Raycast(transform.position, directionToPlayer, out hit, 1000f);
            if (hit.transform.GetComponent<Player>()) {
                agent.SetDestination(transform.position);
                if (directionToPlayer.magnitude <= killZone && Vector3.Dot(directionToPlayer.normalized, transform.position) > 0.65f) {
                    Life playerLife = player.GetComponent<Life>();
                    playerLife.damage(10);
                }
            }
            else {
                agent.SetDestination(player.position);
            }
        }
    }
}
