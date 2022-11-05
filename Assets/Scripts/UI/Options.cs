using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]
    private GameObject vibrationActive;
    [SerializeField]
    private GameObject musicActive;
    [SerializeField]
    private GameObject music;
    private bool vibratorActive = true;
    private bool soundActive = true;

    private void Start()
    {
        if (PlayerPrefs.HasKey("vibration"))
        {
            if (PlayerPrefs.GetInt("vibration") == 0)
            {
                vibratorActive = false;
                vibrationActive.GetComponent<ToggleButton>().Toggle(false);
            }
            else
            {
                vibratorActive = true;
                vibrationActive.GetComponent<ToggleButton>().Toggle(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 1);
            vibrationActive.GetComponent<ToggleButton>().Toggle(true);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("music"))
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                soundActive = false;
                musicActive.GetComponent<ToggleButton>().Toggle(false);
                music.GetComponent<AudioSource>().mute = true;
            }
            else
            {
                soundActive = true;
                musicActive.GetComponent<ToggleButton>().Toggle(true);
                music.GetComponent<AudioSource>().mute = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("music", 1);
            musicActive.GetComponent<ToggleButton>().Toggle(true);
            music.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.Save();
        }
    }
    public void ToggleVibration(GameObject button)
    {
        vibratorActive = !vibratorActive;
        button.GetComponent<ToggleButton>().Toggle(vibratorActive);
        if (vibratorActive)
        {
            PlayerPrefs.SetInt("vibration", 1);
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 0);
        }
        PlayerPrefs.Save();
    }

    public void Vibrate(long milliseconds)
    {
        if (vibratorActive)
            Vibration.Vibrate(milliseconds);
    }

    public void ToggleSound(GameObject button)
    {
        soundActive = !soundActive;
        button.GetComponent<ToggleButton>().Toggle(soundActive);
        music.GetComponent<AudioSource>().mute = !soundActive;
        if (soundActive)
        {
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
        }
        PlayerPrefs.Save();
    }
}
