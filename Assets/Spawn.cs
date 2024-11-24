using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Visitor visitor;
    [SerializeField] private Walker walker;
    // Start is called before the fist frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            Instantiate(visitor, transform.position, Quaternion.identity);
        }
        Instantiate(walker, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(visitor, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(visitor, transform.position, Quaternion.identity);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < 25; i++)
            {
                Instantiate(visitor, transform.position, Quaternion.identity);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(walker, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            for(int i = 0; i < 5; i++)
            {
                Instantiate(walker, transform.position, Quaternion.identity);
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            for(int i = 0; i < 25; i++)
            {
                Instantiate(walker, transform.position, Quaternion.identity);
            }
        }
    }
}
