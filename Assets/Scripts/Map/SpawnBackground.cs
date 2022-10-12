using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackground : MonoBehaviour, ISpawn, ILevel
{
    [SerializeField]
    private Transform spawnPoint;
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
        transform.position = spawnPoint.position;
    }

    public void LoadLevel(int level){
        animator.SetInteger("LevelCount", level);
    }
}