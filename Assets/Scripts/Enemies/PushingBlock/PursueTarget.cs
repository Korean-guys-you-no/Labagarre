using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueTarget : MonoBehaviour
{
    public GameObject Target;

    private UnityEngine.AI.NavMeshAgent Agent;

    private void Awake()
    {
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        Vector3 targetPosition = Target.transform.position;
        RunToTarget(targetPosition);
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
        // transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
        Vector3 pursue = targetPosition /* + transform.forward */;

        return pursue;
    }
}
