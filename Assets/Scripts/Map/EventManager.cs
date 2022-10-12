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
            case 1:
                level = 1;
                break;
            case 2:
                level = 2;
                break;
            case 3:
                level = 3;
                break;
            default:
                break;
        }
    }
}
