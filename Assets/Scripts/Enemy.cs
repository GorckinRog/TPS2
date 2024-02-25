using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform player;
    public float ViewAngle = 45;

    private NavMeshAgent _navMeshAgent;
    private bool isPLayerNoticed;

    private void Start()
    {
        InitComponentLinks();

        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var direction = player.transform.position - transform.position;
    }
}


