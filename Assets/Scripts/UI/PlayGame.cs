using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Play(){
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
