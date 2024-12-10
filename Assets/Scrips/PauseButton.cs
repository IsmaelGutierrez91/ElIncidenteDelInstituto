using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseButton : MonoBehaviour
{
    public float distancia;
    public GameObject optionsPopUp;
    void Awake()
    {
        optionsPopUp.transform.localPosition = new Vector2(optionsPopUp.transform.localPosition.x + distancia, optionsPopUp.transform.localPosition.y);
    }
    public void PauseTheGame()
    {
        if (Time.timeScale == 1)
        {
            StopAllCoroutines();
            Time.timeScale = 0;
            optionsPopUp.transform.localPosition = new Vector2(optionsPopUp.transform.localPosition.x - distancia, optionsPopUp.transform.localPosition.y);
        }
        else
        {
            Time.timeScale = 1;
            optionsPopUp.transform.localPosition = new Vector2(optionsPopUp.transform.localPosition.x + distancia, optionsPopUp.transform.localPosition.y);
        }
    }
    public void GoToGamePlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
