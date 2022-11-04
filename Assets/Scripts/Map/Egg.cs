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
    private int eggActualRun;

    void Start()
    {
        //eggActualRun = PlayerPrefs.GetInt("Egg");
        text.text = eggActualRun.ToString();
    }

    public void Reset()
    {
        eggCount = 0;
        text.text = eggCount.ToString();
    }
    public void AddEgg(bool plus = false)
    {
        try
        {
            egg[eggActualRun].GetComponent<SpriteRenderer>().enabled = true;
        }
        catch (System.Exception)
        {
        }
        eggCount++;
        eggActualRun++;
        text.text = eggCount.ToString();
        if (plus)
        {
            AddEgg();
        }
    }
}
