using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

[Serializable]
public class ItemShop
{
    public string name;
    public string description;
}

[Serializable]
public class ItemsShop
{
    public ItemShop[] items;
}

public class HandlingShop : MonoBehaviour
{
    private int[] prices = { 25, 50, 250, 500, 1000 };
    private string[] itemsShop = { "DobleEgg", "Helmet", "ExtraLive" };
    //private ItemsShop itemsShop;
    private ItemShop itemShop;
    private int levelMax = 5;
    private string json;
    [SerializeField]
    private GameObject saveGame;
    [SerializeField]
    private Text eggCount;

    [SerializeField]
    private GameObject[] powerUps;

    void Start()
    {
        //var path = Application.dataPath + "/Scripts/Shop/ShopItems.json";
        //json = File.ReadAllText(path);
        //itemsShop = JsonUtility.FromJson<ItemsShop>(json);
        foreach (var item in itemsShop)
        {
            if (PlayerPrefs.HasKey("Level" + item))
            {
                foreach (var powers in powerUps)
                {
                    if (powers.GetComponent<PowerUpShop>().nameShop == item)
                    {
                        powers.GetComponent<PowerUpShop>().ActiveLevels(PlayerPrefs.GetInt("Level" + item), prices[PlayerPrefs.GetInt("Level" + item)].ToString());
                        break;
                    }
                }
            }
            else
            {
                PlayerPrefs.SetInt("Level" + item, 0);
            }
        }
        PlayerPrefs.Save();
        eggCount.text = PlayerPrefs.GetInt("Egg").ToString();
    }

    public void BuyItem(string itemName)
    {
        if (PlayerPrefs.GetInt("Level" + itemName) < levelMax)
        {
            if (PlayerPrefs.GetInt("Egg") >= prices[PlayerPrefs.GetInt("Level" + itemName)])
            {
                saveGame.GetComponent<SaveGame>().AddEgg(-prices[PlayerPrefs.GetInt("Level" + itemName)]);
                PlayerPrefs.SetInt("Level" + itemName, PlayerPrefs.GetInt("Level" + itemName) + 1);
                PlayerPrefs.Save();
                eggCount.text = PlayerPrefs.GetInt("Egg").ToString();
            }
            try
            {
                foreach (var powers in powerUps)
                {
                    if (powers.GetComponent<PowerUpShop>().nameShop == itemName)
                    {
                        powers.GetComponent<PowerUpShop>().ActiveLevels(PlayerPrefs.GetInt("Level" + itemName), prices[PlayerPrefs.GetInt("Level" + itemName)].ToString());

                        break;
                    }
                }
            }
            catch (System.Exception)
            {
                foreach (var powers in powerUps)
                {
                    if (powers.GetComponent<PowerUpShop>().nameShop == itemName)
                    {
                        powers.GetComponent<PowerUpShop>().ActiveLevels(PlayerPrefs.GetInt("Level" + itemName), "Max level");
                        break;
                    }
                }
            }
        }
    }

}
