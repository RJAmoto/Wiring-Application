using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Multimeter : MonoBehaviour
{

    public Sprite[] states;
    public int stateCount = 0;

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

    public int getState()
    {
        return stateCount;
    }
}
