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
    [SerializeField]
    private GameObject creditos;

    [SerializeField]
    private GameObject[] diableItems;
    [SerializeField]
    private GameObject[] activeItems;


    public void MarketOpen()
    {
        market.SetActive(true);
        buttonMarket.SetActive(false);
        ChangeVisibility();
        Time.timeScale = 0;
    }

    public void MarketClose()
    {
        Time.timeScale = 1;
        market.SetActive(false);
        buttonMarket.SetActive(true);
        ActiveChangeVisibility();
    }

    public void OptionsOpen()
    {
        Time.timeScale = 0;
        options.SetActive(true);
        ChangeVisibility();
    }

    public void OptionsClose()
    {
        Time.timeScale = 1;
        options.SetActive(false);
        ActiveChangeVisibility();
    }

    public void OpenCredits()
    {
        Application.OpenURL("https://github.com/OptimusDrift/DragonRush");
    }

    private void ChangeVisibility()
    {
        foreach (var item in diableItems)
        {
            item.SetActive(false);
        }
    }
    private void ActiveChangeVisibility()
    {
        foreach (var item in diableItems)
        {
            item.SetActive(true);
        }
    }

    public void VisibilityEggs(GameObject egg)
    {
        egg.SetActive(egg.activeSelf ? false : true);
    }
}

