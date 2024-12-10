using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicSFXController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
    }
    public void ChangeSlider (float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", slider.value);
        AudioListener.volume = slider.value;
    }
}
