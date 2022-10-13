using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private GameObject eggs;
    public int level = 0;


    void Update(){
        switch(eggs.GetComponent<Egg>().eggCount){
            case 20:
                level = 1;
                break;
            case 40:
                level = 2;
                break;
            case 60:
                level = 3;
                break;
            default:
                break;
        }
    }
}
