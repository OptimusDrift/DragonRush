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
    private int userEgg;
    private int[] prices = { 100, 250, 1000, 5000, 10000 };
    private ItemsShop itemsShop;
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
        if (PlayerPrefs.HasKey("Egg"))
        {
            userEgg = PlayerPrefs.GetInt("Egg");
        }
        else
        {
            userEgg = 0;
        }
        var path = Application.dataPath + "/Scripts/Shop/ShopItems.json";
        json = File.ReadAllText(path);
        itemsShop = JsonUtility.FromJson<ItemsShop>(json);
        foreach (var item in itemsShop.items)
        {
            if (PlayerPrefs.HasKey("Level" + item.name))
            {
                PlayerPrefs.GetInt("Level" + item.name);
                foreach (var powers in powerUps)
                {
                    if (powers.GetComponent<PowerUpShop>().nameShop == item.name)
                    {
                        powers.GetComponent<PowerUpShop>().ActiveLevels(PlayerPrefs.GetInt("Level" + item.name), prices[PlayerPrefs.GetInt("Level" + item.name)].ToString());
                        break;
                    }
                }
            }
            else
            {
                PlayerPrefs.SetInt("Level" + item.name, 0);
            }
        }
        PlayerPrefs.Save();
    }
    public void BuyItem(string itemName)
    {
        Debug.Log(itemName);
        if (PlayerPrefs.GetInt("Level" + itemName) < levelMax)
        {
            if (userEgg >= PlayerPrefs.GetInt("Level" + itemName))
            {
                userEgg -= prices[PlayerPrefs.GetInt("Level" + itemName)];
                saveGame.GetComponent<SaveGame>().AddEgg(-prices[PlayerPrefs.GetInt("Level" + itemName)]);
                PlayerPrefs.SetInt("Level" + itemName, PlayerPrefs.GetInt("Level" + itemName) + 1);
                PlayerPrefs.Save();
                eggCount.text = userEgg.ToString();
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
