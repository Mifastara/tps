using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }

    // Update is called once per frame
    private void Update()
    {
        NotisePlayerUpdate();
        ChaseUpdate();

        PatrolUpdate();
    }
    private void NotisePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }

            }
        }
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints [Random.Range(0, patrolPoints.Count)].position;
    }
}
