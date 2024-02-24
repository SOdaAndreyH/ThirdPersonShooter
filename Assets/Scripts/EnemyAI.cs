using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> TPoints;
    public PlayerController Player;
    public float ViewAngle;

    private NavMeshAgent _agent;
    private bool _isPlayerNoticed;

    void Start()
    {
        Components();
    }


    void Update()
    {
        NotiecePlayerUpdate();
        ChaseUpdate();
        PatrolUnpade();
    }

    private void Components()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void PatrolUnpade()
    {
        if(_isPlayerNoticed == false)
        {
            if (_agent.remainingDistance < _agent.stoppingDistance)
            {
                PickNewPoint();
            }
        }
    }

    private void PickNewPoint()
    {
        _agent.SetDestination(TPoints[Random.Range(0, TPoints.Count)].position);
    }

    private void ChaseUpdate() 
    {
        if (_isPlayerNoticed)
        {
            _agent.destination = Player.transform.position;
        }
    }

    private void NotiecePlayerUpdate()
    {
    var direction = Player.transform.position - transform.position;

    _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

}
