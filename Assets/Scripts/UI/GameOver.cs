using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject contoller;

    public void StopGame(){
        Time.timeScale = 0;
        contoller.SetActive(false);
    }

    public void RestartGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Example 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
