using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public AudioSource[] click;
    public List<GameObject> connections = new List<GameObject>();
    public GameObject[] connection;
    int connectionIndex = 0;
    public Pair[] answerPairs;
    bool connectionsCorrect = true;

    public Animator CheckAnimation;
    public TextMeshProUGUI checkText;
    public bool canMoveNext = false;

    public Multimeter multimeter;
    public int correctMultimeterStatusCount;

    public bool multimeterRecommended; 
    void Start()
    {

    }
    void Update()
    {
        if (connection[connectionIndex].GetComponent<Connector>().isFull())
        {
            connections.Add(connection[connectionIndex]);
            connectionIndex += 1;
        }
    }

    public void addConnection(GameObject node)
    {
        if (!(connection[connectionIndex].GetComponent<Connector>().isFull()))  
      {

            connection[connectionIndex].GetComponent<Connector>().Connect(node);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void check()
    {
        int wire1, wire2;
        int answer1, answer2;

        for (int a = 0; a < connections.Count; a++)
        {
            wire1 = connections[a].GetComponent<Connector>().getNodes()[0].GetComponent<Node>().getID();
            wire2 = connections[a].GetComponent<Connector>().getNodes()[1].GetComponent<Node>().getID();

            for (int b = 0; b < answerPairs.Length; b++)
            {
                answer1 = answerPairs[b].getA();
                answer2 = answerPairs[b].getB();


                if (wire1 == answer1)
                {
                    if (wire2 == answer2)
                    {
                        connection[a].GetComponent<Connector>().setCorrect(true);
                        Debug.Log("Wire 1: " + wire1 + " Wire 2: " + wire2 + " Answer 1: " + answer1 + " Answer 2: " + answer2);
                    }
                }
                else if (wire1 == answer2)
                {
                    if (wire2 == answer1)
                    {
                        connection[a].GetComponent<Connector>().setCorrect(true);
                        Debug.Log("Wire 1: " + wire1 + " Wire 2: " + wire2 + " Answer 1: " + answer1 + " Answer 2: " + answer2);
                    }
                }
            }
            Debug.Log("Wire " + a + " connection correct: " + connection[a].GetComponent<Connector>().isCorrectConnection());
        }
        if(connections.Count <= 0)
        {
            connectionsCorrect = false;
        }
        if (multimeterRecommended)
        {
            if (multimeter.getState() != correctMultimeterStatusCount)
            {
                connectionsCorrect = false;
            }
        }

        for (int c = 0; c < connections.Count; c++) {
            if (!connection[c].GetComponent<Connector>().isCorrect || connections.Count<answerPairs.Length)
            {
                connectionsCorrect = false;
            }
        }

        if (connectionsCorrect)
        {
            checkText.SetText("Correct");
            checkText.color = new Color(0f, 100f, 0f);
            CheckAnimation.SetTrigger("Activate");
            canMoveNext = true;
            checkText.fontSize = 36;
        }
        else
        {
            checkText.SetText("Wrong");
            checkText.color = new Color(100f, 0f, 0f);
            CheckAnimation.SetTrigger("Activate");
            checkText.fontSize = 36;
        }
    }
    public void exit(){
        SceneManager.LoadScene(0);
    }

    public void next(int CourseBuildIndex)
    {
        if (canMoveNext) {
            SceneManager.LoadScene(CourseBuildIndex);
        }
        else
        {
            checkText.SetText("You haven't completed this run yet!");
            checkText.color = new Color(50f, 50f, 0f);
            CheckAnimation.SetTrigger("Activate");
            checkText.fontSize = 15;
        }
    }

    public void undo()
    {
        connections[connections.Count - 1].GetComponent<Connector>().restart();

        connections.RemoveAt(connections.Count-1);

    }

    public void clickSound()
    {
        click[0].Play();
    }

    public void unPlug()
    {
        click[1].Play();
    }

    public void rotateMultimeter()
    {
        click[2].Play();
    }
}

