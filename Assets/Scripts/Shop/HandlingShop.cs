using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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
            }
            else
            {
                PlayerPrefs.SetInt("Level" + item.name, 0);
            }
        }
    }
    public void BuyItem(string itemName)
    {
        if (PlayerPrefs.GetInt("Level" + itemName) < levelMax)
        {
            Debug.Log("Level" + itemName + " " + PlayerPrefs.GetInt("Level" + itemName));
            Debug.Log(userEgg);
            if (userEgg >= PlayerPrefs.GetInt("Level" + itemName))
            {
                userEgg -= prices[PlayerPrefs.GetInt("Level" + itemName)];
                PlayerPrefs.SetInt("Egg", userEgg);
                PlayerPrefs.SetInt("Level" + itemName, PlayerPrefs.GetInt("Level" + itemName) + 1);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("Not enough eggs");
            }
        }
    }

}
