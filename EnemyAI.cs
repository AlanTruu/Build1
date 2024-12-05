using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
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
    // Start is called before the first frame update
    
    private void Awake() {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void patrolling() {
        if (!walkPointSet) searchWalkPoint();
        if (walkPointSet) {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 0.5f) {
            walkPointSet = false;
        }
    }
    
    private void searchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) {
            walkPointSet = true;
        }

    }

    private void chase() {
        agent.SetDestination(player.position);
    }
    private void attack() {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked) {
            alreadyAttacked = true;
            GameObject fireball = Instantiate(fireballPrefab) as GameObject;
            fireball.transform.position = transform.TransformPoint(Vector3.forward*1.5f);
            fireball.transform.rotation = transform.rotation;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    private void resetAttack() {
        alreadyAttacked = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) patrolling();
        if (playerInSightRange && !playerInAttackRange) chase();
        if (playerInSightRange && playerInAttackRange) attack();
    }
}
