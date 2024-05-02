using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Niveau1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Niveau2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Niveau3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Niveau4");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
