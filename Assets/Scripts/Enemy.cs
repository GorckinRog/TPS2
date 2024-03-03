using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform player;
    public float ViewAngle = 45;
    public float MinDetectDistance = 3;
    public float Damage = 10;
    public PlayerHealth _playerHealth;

    private NavMeshAgent _navMeshAgent;   
    private bool _isPLayerNoticed;

    private void Start()
    {
        InitComponentLinks();      
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = GetComponent<PlayerHealth>();   
    }

    private void Update()
    {

        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPLayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPLayerNoticed = true;
                }
            }
        }
    }
    private void PatrolUpdate()
    {
        if (!_isPLayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }
    private void ChaseUpdate()
    {
        if (_isPLayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

}


