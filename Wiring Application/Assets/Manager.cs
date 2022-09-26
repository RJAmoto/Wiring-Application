using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update

    List<Connector> connector = new List<Connector>();
    public GameObject[] nodes;
    public int[] count;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void process()
    {

    }

    public void addConnection(Connector connect)
    {
        connector.Add(connect);
    }
    public void removeConnection(Connector connect)
    {
        connector.Remove(connect);
    }
    
    public List<Connector> getConnections()
    {
        return connector;
    }
}

