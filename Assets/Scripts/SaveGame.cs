using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private int egg;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Egg"))
        {
            egg = PlayerPrefs.GetInt("Egg");
        }
        else
        {
            egg = 0;
        }
    }
    private void Save()
    {
        PlayerPrefs.SetInt("Egg", egg);
        PlayerPrefs.Save();
    }

    public void AddEgg(int eggs)
    {
        egg = eggs;
        Save();
    }

    public int GetEgg()
    {
        return egg;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
