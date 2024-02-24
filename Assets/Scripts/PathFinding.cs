using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public List<Transform> Points;

    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_agent.remainingDistance < _agent.stoppingDistance)
        {
            _agent.SetDestination(Points[Random.Range(0,Points.Count)].position);
        }


    }
}
