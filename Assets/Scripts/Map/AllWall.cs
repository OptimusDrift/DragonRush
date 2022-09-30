using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWall : MonoBehaviour, IWiggle
{
    [SerializeField]
    private GameObject[] walls;
    void Start()
    {
        
    }

    public void Wiggles()
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<IWiggle>().Wiggles();
        }
    }
}
