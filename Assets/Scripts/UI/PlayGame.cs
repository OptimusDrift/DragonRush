using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    private GameObject dragon;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private GameObject titulo;
    void Start()
    {
    }

    public void Play(){
        dragon.gameObject.GetComponent<DragonController>().Play();
        spawner.gameObject.GetComponent<SpawnRocks>().Play();
        gameObject.SetActive(false);
        titulo.SetActive(false);
    }
}
