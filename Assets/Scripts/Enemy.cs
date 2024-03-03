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
        _playerHealth = player.GetComponent<PlayerHealth>();   
    }

    private void Update()
    {

        
        ChaseUpdate();
        PatrolUpdate();
        PlayerDamage();
        
    }
    private void PlayerDamage()
    {
        if (CheckPlayer())
        {
            _navMeshAgent.SetDestination(player.position);
            //Если оставшееся расстояние меньше или равно, чем дистанция остановки
            if (_navMeshAgent.remainingDistance <= MinDetectDistance)
            {
                //Отнять от здоровья игрока Damage в секунду
                _playerHealth.TakeDamage(Damage);
            }
        }
        else
        {
            PatrolUpdate();
        }
    }
    bool CheckPlayer()
    {
        Vector3 direction = player.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle || Vector3.Distance(transform.position, player.position) < MinDetectDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
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


