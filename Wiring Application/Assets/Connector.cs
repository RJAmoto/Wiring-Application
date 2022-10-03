using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connector : MonoBehaviour
{
    // Start is called before the first frame update
    
    public LineRenderer line;
    bool full = false;
    public bool isCorrect;

    List<GameObject> nodes = new List<GameObject>();

    void Start()
    {
        line.positionCount = 2;
        line.SetPosition(0, new Vector3(0,0,0));
        line.SetPosition(1, new Vector3(0,0,0));
        full = false;
        isCorrect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nodes.Count <= 1)
        {
            line.SetPosition(0, nodes[0].transform.position);
            line.SetPosition(1, nodes[0].transform.position);
        }
        else if(nodes.Count >=2)
        {
            line.SetPosition(0, nodes[0].transform.position);
            line.SetPosition(1, nodes[1].transform.position);
            full = true;
        }
    }

    public void Connect(GameObject node)
    {
            nodes.Add(node);
    }

    public bool isFull()
    {
        return full;
    }

    public void restart()
    {
        nodes.Clear();
        line.SetPosition(0, new Vector3(0, 0, 0));
        line.SetPosition(1, new Vector3(0, 0, 0));
        full = false;
    }

    public List<GameObject> getNodes()
    {
        return nodes;
    }
    public bool isCorrectConnection()
    {
        return isCorrect;
    }
    public void setCorrect(bool correct)
    {
        isCorrect = correct;
    }
}
