using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Egg : MonoBehaviour
{
    [SerializeField]
    private GameObject[] egg;
    [SerializeField]
    private Text text;
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
        text.text = eggCount.ToString();
        
    }
}
