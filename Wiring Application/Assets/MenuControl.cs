using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreateDesign()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}
