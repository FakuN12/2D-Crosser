using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //private LevelChanger menufade;

    public void PlayGame()
    {

    }

    private void Gamestart()
    {
        System.Threading.Thread.Sleep(3000);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
