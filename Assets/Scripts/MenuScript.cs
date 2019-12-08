using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void StartGame()
    {
        // "Stage1" is the name of the first scene we created.
        SceneManager.LoadScene("Stage1");
    }

    public void Highscore()
    {
        // Display highscores
        SceneManager.LoadScene("Hightscores");
    }

    public void MainMenu()
    {
        // "Display Main Menu
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
