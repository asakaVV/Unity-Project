using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Struct : MonoBehaviour
{
    private Transform _enter;
    private Transform _exit;
    
    private Queue<VisitorInfo> _visitingQueue = new Queue<VisitorInfo>();
    private Queue<Visitor> _queue = new Queue<Visitor>();
    
    private Vector3 _lastVisitor;
    
    [SerializeField] private int _maxVisitors;
    [SerializeField] private float _time;
    // Start is called before the first frame update
    
    public Transform get_enter()
    {
        return _enter;
    }
    
    public Transform get_exit()
    {
        return _exit;
    }
    
    public Vector3 get_lastCube()
    {
        return _lastVisitor;
    }
    void Start()
    {
        _enter = transform.Find("Entrance");
        _exit = transform.Find("Exit");
        _lastVisitor = _enter.position;
    }
    
    void majVisitingCubes()
    {
        if (_visitingQueue.Count == 0)
        {
            return;
        }
        float currentTime = Time.time;
        VisitorInfo firstVisitor = _visitingQueue.Peek();
        if (currentTime - firstVisitor.get_time() > _time)
        {
            firstVisitor = _visitingQueue.Dequeue();
            firstVisitor.get_cube().exitVisit();
        }
    }
    
    public void addVisitor(Visitor visitor)
    {
        _queue.Enqueue(visitor);
        _lastVisitor = visitor.transform.position;
    }
    
    public void goToLast()
    {
        if (_queue.Count == 0)
        {
            return;
        }
        if (_visitingQueue.Count == _maxVisitors)
        {
            return;
        }
        var previous = _queue.Peek();
        foreach (var c in _queue)
        {
            if (c == previous)
            {
                c.get_agent().SetDestination(_enter.position);
                c.get_agent().isStopped = false;
            }
            else
            {
                if ((previous.transform.position - c.transform.position).magnitude > 1.1f)
                {
                    c.get_agent().SetDestination(previous.transform.position);
                    c.get_agent().isStopped = false;
                }
            }
            if (c.get_agent().remainingDistance < 1.1f)
            {
                c.get_agent().isStopped = true;
            }
            previous = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_visitingQueue.Count < _maxVisitors && _queue.Count > 0)
        {
            Visitor visitor = _queue.Peek();
            if ((visitor.transform.position - _enter.position).magnitude < 2f)
            {
                visitor = _queue.Dequeue();
                visitor.goToVisit();
                _visitingQueue.Enqueue(new VisitorInfo(visitor));
            }
        }
        majVisitingCubes();
        goToLast();
        
    }
}
