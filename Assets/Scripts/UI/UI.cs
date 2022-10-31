using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] 
    private GameObject market;
    [SerializeField]
    private GameObject buttonMarket;
    [SerializeField]
    private GameObject options;
    

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

    public void OptionsOpen()
    {
        Time.timeScale = 0;
        options.SetActive(true);
    }

    public void OptionsClose()
    {
        Time.timeScale = 1;
        options.SetActive(false);
    }
}
