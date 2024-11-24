using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Visitor : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    [SerializeField] private Struct[] structs;
    
    private bool _isVisiting = false;
    
    private int _currentStructIndex;
    
    private Vector3 _exitPos;
    
    private bool _isQueuing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentStructIndex = -1;
    }

    public void goToVisit()
    {
        _isVisiting = true;
        _exitPos = structs[_currentStructIndex].get_exit().position;
        _currentStructIndex = -1;
    }

    public void exitVisit()
    {
        _isVisiting = false;
    }

    public NavMeshAgent get_agent()
    {
        return _agent;
    }

    // Update is called once per frame
    void Update()
    {
        Collider collider = GetComponent<Collider>();
        Renderer renderer = GetComponent<Renderer>();
        if (_isVisiting)
        {
            collider.enabled = false;
            renderer.enabled = false;
            _agent.Warp(_exitPos);
            _agent.enabled = false;
            _isQueuing = false;
        }
        if (!_isVisiting && _currentStructIndex == -1)
        {
            collider.enabled = true;
            renderer.enabled = true;
            _agent.enabled = true;
            
            _currentStructIndex = Random.Range(0, structs.Length);
            _agent.SetDestination(structs[_currentStructIndex].get_lastCube());
        }

        if (_agent.hasPath && !_agent.pathPending && _agent.remainingDistance < 2f && !_isQueuing)
        {
            structs[_currentStructIndex].addVisitor(this);
            _isQueuing = true;
        }
    }
}
