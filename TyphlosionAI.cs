using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TyphlosionAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    [SerializeField] private GameObject fireballPrefab;
    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
    private void Awake() {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    public void searchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(randomX + transform.position.x, transform.position.y, randomZ + transform.position.z);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer)) {
            walkPointSet = true;
        }
    }
    private void patrolling () {
        if (!walkPointSet) searchWalkPoint();
        if (walkPointSet) {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceTo = walkPoint - transform.position;
        if (distanceTo.magnitude < 0.5f) {
            walkPointSet = false;
        }
    }

    private void chase() {
        if (playerInSightRange) {
            agent.SetDestination(player.position);
        }
    }
    
    private void resetAttack() {
        alreadyAttacked = false;
    }
    private void attack() {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked) {
            alreadyAttacked = true;
            GameObject fireball = Instantiate(fireballPrefab) as GameObject;
            Vector3 playerElevation = new Vector3(player.position.x, transform.position.y, player.position.z);
            
            fireball.transform.position = transform.TransformPoint(Vector3.forward*3f + new Vector3(0, playerElevation.y - transform.position.y, 0));
            fireball.transform.rotation = transform.rotation;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (!playerInSightRange && !playerInAttackRange) patrolling();
        if (playerInSightRange && !playerInAttackRange) chase();
        if (playerInSightRange && playerInAttackRange) attack();

    }
}
