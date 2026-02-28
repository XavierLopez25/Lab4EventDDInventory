using UnityEngine;
using UnityEngine.AI;

public class ZombiePatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;

    private NavMeshAgent agent;
    private Animator animator;
    private int currentPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }
}