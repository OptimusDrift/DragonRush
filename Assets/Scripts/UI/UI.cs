using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] 
    private GameObject market;
    [SerializeField]
    private GameObject buttonMarket;
    

    public void MarketOpen()
    {  
        Time.timeScale = 0;
        market.SetActive(true);
        buttonMarket.SetActive(false);             
    }

    public void MarketClose()
    {
        Time.timeScale = 1;
        market.SetActive(false);
        buttonMarket.SetActive(true);
    }
}
