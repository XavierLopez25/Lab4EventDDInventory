using UnityEngine;
using UnityEngine.AI;

public class ZombieChaser : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 2f;
    
    private float lastAttackTime = -Mathf.Infinity;
    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;

    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
            }
        }
        else if (distance <= chaseRange)
        {
            Chase();
        }
        else
        {
            Idle();
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void Chase()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);

        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        agent.isStopped = true;

        animator.SetTrigger("Attack");

        lastAttackTime = Time.time;
    }

    void Idle()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);

        agent.isStopped = true;
    }
}