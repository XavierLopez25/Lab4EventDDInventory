using UnityEngine;
using UnityEngine.AI;

public class ZombieGuard : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private float guardRange = 25f;
    [SerializeField] private float attackRange = 2.5f;
    [SerializeField] private float attackCooldown = 2.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;

    private Vector3 startPosition;
    private float lastAttackTime = -Mathf.Infinity;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        startPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceFromStart = Vector3.Distance(player.position, startPosition);

        if (distanceFromStart <= guardRange)
        {
            if (distanceToPlayer <= attackRange)
            {
                Attack();
            }
            else
            {
                ChasePlayer();
            }
        }
        else
        {
            ReturnToPost();
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        agent.isStopped = true;

        if (Time.time >= lastAttackTime + attackCooldown)
        {
            animator.SetTrigger("Attack");
            lastAttackTime = Time.time;
        }
    }

    void ReturnToPost()
    {
        agent.isStopped = false;
        agent.SetDestination(startPosition);
    }
}