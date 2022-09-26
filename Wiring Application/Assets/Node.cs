using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject connectedNode;
    public Toggle toggle;
    public Sprite nodeNormal;
    public Sprite nodeHighlighted;
    LineRenderer line;

    bool isAvailable = true;

    void Start()
    {
        line = new LineRenderer();
    }

    // Update is called once per frame
    void Update()
    {
        if (connectedNode != null)
        {
            if (toggle.isOn)
            {
            }
            else
            {


            }
        }
        else
        {
            if (toggle.isOn)
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, new Vector3(0, 0));
            }
            else
            {


            }
        }

    }

    public void Select()
    {
        if (toggle.isOn)
        {
            toggle.image.sprite = nodeHighlighted;
            isAvailable = false;
        }
        else
        {
            toggle.image.sprite = nodeNormal;
            isAvailable = true;
        }
    }

    public void setAvailable(bool available)
    {
        isAvailable = available;
    }

    public bool getAvailable()
    {
        return isAvailable;
    }
}
