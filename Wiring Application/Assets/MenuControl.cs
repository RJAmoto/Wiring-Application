using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void LoadCourse(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}
