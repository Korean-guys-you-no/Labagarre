using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTarget : MonoBehaviour
{
    public bool knockBack;

    private GameObject Target;
    private UnityEngine.AI.NavMeshAgent Agent;
    private GameObject[] Players;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        SelectTarget();

        if (Target != null && knockBack == false)
        {
            Vector3 targetPosition = Target.transform.position;
            RunToTarget(targetPosition);
        } else if (knockBack == true)
        {
            rigidBody.AddForce(rigidBody.velocity);
        }
    }

    private void SelectTarget()
    {
        Target = null;

        foreach (var player in Players)
        {
            Vector3 pos = (player.transform.position - transform.position);
            if (pos.magnitude < 5.5f)
            {
                Target = player;
                break;
            }
        }
        
    }

    private void RunToTarget(Vector3 targetPosition)
    {
        Vector3 destination = PositionToPursue(targetPosition);
        HeadForDestination(destination);
    }

    private void HeadForDestination(Vector3 destination)
    {
        Agent.SetDestination(destination);
    }

    private Vector3 PositionToPursue(Vector3 targetPosition)
    {
        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
        Vector3 pursue = targetPosition + transform.forward;

        return pursue;
    }
}
