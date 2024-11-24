using UnityEngine;

public class VisitorInfo
{
    private Visitor _visitor;
    private float time;
    
    public VisitorInfo(Visitor visitor)
    {
        this._visitor = visitor;
        this.time = Time.time;
    }
    
    public Visitor get_cube()
    {
        return _visitor;
    }
    
    public float get_time()
    {
        return time;
    }
}