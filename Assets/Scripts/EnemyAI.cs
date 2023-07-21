using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    float distanceToTarget = Mathf.Infinity;
    EnemyHealth health;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (health.isDead)
        {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }
    
    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("Attack", false);
            ChaseTarget();
        }
        else 
        {
            AttackTarget();
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
       
    }
    public void OnDamageTaken() {
        if (!isProvoked) isProvoked = true;
    }

}
