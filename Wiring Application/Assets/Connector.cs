using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connector : MonoBehaviour
{
    // Start is called before the first frame update
    
    public LineRenderer line;
    public Material lineMat;
    bool full = false;
    public Toggle toggle;
    Manager manager;

    List<GameObject> nodes = new List<GameObject>();

    void Start()
    {
        line.positionCount = 2;
        line.SetPosition(0, new Vector3(0,0,0));
        line.SetPosition(1, new Vector3(0,0,0));
        line.material = lineMat;
        line.startWidth = 0;
        line.endWidth = 1f;

        GameObject newLine = new GameObject("Line");
        line = newLine.AddComponent<LineRenderer>();

        full = false;
    }

    // Update is called once per frame
    void Update()
    {
            line.SetPosition(0, nodes[0].transform.position);
            line.SetPosition(1, nodes[1].transform.position);

            if (nodes.Count >= 2)
            {
                full = true;
                if (!manager.getConnections().Contains(this)) {
                    manager.addConnection(this);
                    nodes.Clear();
                    line = null;
                }
            }
    }

    public void Connect(GameObject node)
    {
        if (nodes.Count > 2)
        {
            return;
        }
        else
        {
            nodes.Add(node);
        }
    }

    public void removeConnect()
    {
        nodes.Clear();
        manager.getConnections().Remove(this);
    }

    public bool isEven()
    {
        if ((nodes.Count % 2) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
