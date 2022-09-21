using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField]
    private GameObject[] egg;
    public int eggCount = 0;

    public void AddEgg(){
        try
        {
            egg[eggCount].GetComponent<SpriteRenderer>().enabled = true;
        }
        catch (System.Exception)
        {
        }
        eggCount++;
    }
}
