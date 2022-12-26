using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;

    public void StopAnim()
    {
        anim.SetBool("Start", false);
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fadeout");
    }

    public void OnFadeComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void endScreen()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            FadeToLevel();
        }
    }

}
