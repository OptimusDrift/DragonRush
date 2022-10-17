using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private GameObject eggs;
    public int level = 0;

    private int[] levels = {20, 40, 60};


    void Update(){
        if (eggs.GetComponent<Egg>().eggCount < levels[levels.Length - 1])
        {
            for (int i = level; i < levels.Length; i++)
            {
                if (eggs.GetComponent<Egg>().eggCount == levels[i])
                {
                    level = i + 1;
                    Debug.Log("Level " + level);
                    Firebase.Analytics.FirebaseAnalytics.LogEvent("level_" + level);
                    break;
                }
            }
        }
    }
}
