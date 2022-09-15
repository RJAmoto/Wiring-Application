using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform pos1;
    public Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, pos1.position);
        lineRenderer.SetPosition(1, pos2.position);
    }
}
