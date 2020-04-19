using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void SwitchToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SwitchToGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void SwitchToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
