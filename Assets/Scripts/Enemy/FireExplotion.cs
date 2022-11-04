using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplotion : MonoBehaviour
{
    public ParticleSystem explotion;
    public bool play = false;
    private int count = 0;
    private void Update()
    {
        if (play && count == 0)
        {
            count++;
            GetComponent<ParticleSystem>().Play();
            explotion.Play();
            play = false;
        }
        
    }
}
