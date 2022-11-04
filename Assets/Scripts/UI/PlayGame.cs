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
    [SerializeField]
    private GameObject shop;
    void Start()
    {
    }

    public void Play()
    {
        shop.SetActive(false);
        dragon.gameObject.GetComponent<DragonController>().Play();
        spawner.gameObject.GetComponent<SpawnRocks>().Play();
        gameObject.SetActive(false);
        titulo.SetActive(false);
    }
}
