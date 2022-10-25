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
    public TextMeshProUGUI CountText;
    public bool canMoveNext = false;

    public Multimeter multimeter;
    public int correctMultimeterStatusCount;
    public bool connectAllowed = true;
    public bool multimeterRecommended;
    float time = 7;
    public bool willExit = false;
    void Start()
    {
        CountText.fontSize = 0;
    }
    void Update()
    {
        if (connection[connectionIndex].GetComponent<Connector>().isFull())
        {
            connections.Add(connection[connectionIndex]);
            connectionIndex += 1;

            if (connections[connections.Count-1].GetComponent<Connector>().getNodes()[0]==connections[connections.Count - 1].GetComponent<Connector>().getNodes()[1])
            {
                undo();
            }
        }

        if (willExit) {
            time -= 1 * Time.deltaTime;

            if (time <= 6)
            {
                if (time <= 0)
                {
                    time = 0;
                }
                CountText.fontSize = 36;
                CountText.color = new Color(0f, 0f, 255f);
                CountText.SetText("" + (int)time + "");
            }

            if (time <= 0)
            {
                Application.Quit();
                Debug.Log("Application Quitting");
            }
        }
    }

    public void addConnection(GameObject node)
    {
        if (connectAllowed)
        {
            if (!(connection[connectionIndex].GetComponent<Connector>().isFull()))
            {

                connection[connectionIndex].GetComponent<Connector>().Connect(node);
            }
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void check()
    {
        if (connectAllowed)
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
                        }
                    }
                    else if (wire1 == answer2)
                    {
                        if (wire2 == answer1)
                        {
                            connection[a].GetComponent<Connector>().setCorrect(true);
                        }
                    }
                }
            }
            if (connections.Count <= 0)
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

            for (int c = 0; c < connections.Count; c++)
            {
                if (!connection[c].GetComponent<Connector>().isCorrect || connections.Count < answerPairs.Length)
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
                connectAllowed = false;
            }
            else
            {
                checkText.SetText("Wrong");
                checkText.color = new Color(100f, 0f, 0f);
                CheckAnimation.SetTrigger("Activate");
                checkText.fontSize = 36;
            }
        }
        else
        {
            checkText.SetText("This is already finished");
            checkText.color = new Color(100f, 0f, 0f);
            CheckAnimation.SetTrigger("Activate");
            checkText.fontSize = 36;
        }
    }

    public void submit()
    {
        if (connectionsCorrect)
        {   
            checkText.SetText("Submitted");
            checkText.color = new Color(0f, 0f, 255f);
            CheckAnimation.SetTrigger("Activate");
            checkText.fontSize = 36;

            willExit = true;
        }
    }
    public void exit(){
        SceneManager.LoadScene(0);
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

