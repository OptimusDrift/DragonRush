using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject toggleObjectActive;
    public GameObject toggleObjectDesactive;

    public void Toggle(bool isActive)
    {
        toggleObjectActive.SetActive(isActive);
        toggleObjectDesactive.SetActive(!isActive);
    }
}
