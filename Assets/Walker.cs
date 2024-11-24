using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(new Vector3(Random.Range(15, 90), transform.position.y, Random.Range(15, 90)));
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.hasPath && !_agent.pathPending && _agent.remainingDistance < 1.0f)
        {
            _agent.SetDestination(new Vector3(Random.Range(15, 90), transform.position.y, Random.Range(15, 90)));
        }
    }
}
