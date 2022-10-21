using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]
    private Text vibrationActiveText;
    [SerializeField]
    private Text musicActiveText;
    [SerializeField]
    private GameObject music;
    private bool vibratorActive = true;
    private bool soundActive = true;

    public void ToggleVibration()
    {
        vibratorActive = !vibratorActive;
        vibrationActiveText.text = "Vibration: " + (vibratorActive ? "On" : "Off");
    }

    public void Vibrate(long milliseconds)
    {
        if (vibratorActive)
            Vibration.Vibrate(milliseconds);
    }

    public void ToggleSound()
    {
        soundActive = !soundActive;
        musicActiveText.text = "Music: " + (soundActive ? "On" : "Off");
        music.GetComponent<AudioSource>().mute = !soundActive;
    }
}
