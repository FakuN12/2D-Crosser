using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button WoodButton;
    public Button StoneButton;
    public Button MetalButton;
    public BarCreator barCreator;

    private void Start()
    {
        StoneButton.onClick.Invoke();
    }

    public void Play()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ChangeBar(int myBarType)
    {
        if (myBarType == 0)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            StoneButton.GetComponent<Outline>().enabled = true;
            MetalButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.StoneBar;
        }
        if (myBarType == 1)
        {
            WoodButton.GetComponent<Outline>().enabled = true;
            StoneButton.GetComponent<Outline>().enabled = false;
            MetalButton.GetComponent<Outline>().enabled = false;
            barCreator.BarToInstantiate = barCreator.WoodBar;
        }
        if (myBarType == 2)
        {
            WoodButton.GetComponent<Outline>().enabled = false;
            StoneButton.GetComponent<Outline>().enabled = false;
            MetalButton.GetComponent<Outline>().enabled = true;
            barCreator.BarToInstantiate = barCreator.MetalBar;
        }

    }
}
