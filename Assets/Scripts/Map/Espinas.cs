using System.Collections;
using System.Collections.Generic;
using EasyMobileInput.PlayerController;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    void Start(){

    }
    //CODIGO xD MEJORAR DESPUES
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GetComponent<Animator>().GetInteger("TipoObstaculo") == 2){
                if (GetComponent<Animator>().GetInteger("LevelCount") == 3)
                {
                    other.gameObject.GetComponent<PlayerController>().PlayerDeath();
                }
            }
        }
    }
}
