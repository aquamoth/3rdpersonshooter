using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private AggroDetection aggroDetection;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void Update()
    {
        var speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);

    }
}
