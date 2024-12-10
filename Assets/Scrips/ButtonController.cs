using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    public int hePlayedBefore;
    public void Start()
    {
        hePlayedBefore = PlayerPrefs.GetInt("hePlayedBefore", 0);
    }
    public void GoToTutorial()
    {
        if (hePlayedBefore == 1)
        {
            SceneManager.LoadScene("Gameplay");
        }
        if (hePlayedBefore == 0)
        {
            hePlayedBefore = 1;
            PlayerPrefs.SetInt("hePlayedBefore", hePlayedBefore);
            SceneManager.LoadScene("Tutorial");
        }
    }
    public void GoToGamePlay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void GotToMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
