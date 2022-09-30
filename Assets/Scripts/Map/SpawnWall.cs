using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour, ISpawn
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        wall.transform.position = spawnPoint.position;
    }
}