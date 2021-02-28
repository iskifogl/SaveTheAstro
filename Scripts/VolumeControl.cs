using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    private static readonly string FirstPlay = "Firstplay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlay;
    public Slider  volumeSlider;
    private float  backgroundFloat;
    public AudioSource backgroundAudio;

    void Start()
    {
        firstPlay = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlay == 0)
        {
            backgroundFloat = .125f;
            volumeSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

        else
        {
          backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            volumeSlider.value = backgroundFloat;
        }

    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, volumeSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = volumeSlider.value;
        // backgroundAudio_2.volume = volumeSlider.value;


    }

}
