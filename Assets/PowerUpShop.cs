using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpShop : MonoBehaviour
{
    public string nameShop;
    public GameObject[] levels;
    public Text text;


    public void ActiveLevels(int level, string price)
    {
        text.text = price;
        for (int i = 0; i < level; i++)
        {
            levels[i].GetComponent<Animator>().SetBool("isActive", true);
        }
    }
}
