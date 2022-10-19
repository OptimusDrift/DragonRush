using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Text vibrationActiveText;
    private bool vibratorActive = true;

    public void ToggleVibration()
    {
        vibratorActive = !vibratorActive;
        vibrationActiveText.text = "Vibration: " + (Vibration.vibratorActive ? "On" : "Off");
    }

    public void Vibrate(long milliseconds)
    {
        if (vibratorActive)
            Vibration.Vibrate(milliseconds);
    }
}
