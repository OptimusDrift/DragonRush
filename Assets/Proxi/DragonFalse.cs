using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFalse : MonoBehaviour
{
    [SerializeField] private GameObject dragon;
    public void DragonApagado()
    {
        dragon.SetActive(!dragon.activeSelf);
    }
}
