using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour, ISpawn, ILevel
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject wall;
    [SerializeField]
    private Animator animator;
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

    public void LoadLevel(int level){
        animator.SetInteger("LevelCount", level);
    }
}