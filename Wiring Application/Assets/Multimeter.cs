using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Multimeter : MonoBehaviour
{

    public Sprite[] states;
    public int stateCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Turn() {
        if (stateCount<(states.Length)-1)
        {
            stateCount += 1;
        }
        else
        {
            stateCount = 0;
        }

        this.gameObject.GetComponent<Image>().sprite = states[stateCount];
    }
}
