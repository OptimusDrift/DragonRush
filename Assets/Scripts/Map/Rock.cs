using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private Collider2D col;
    private bool destroyed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroyed(){
        if(destroyed) return;
        col.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        particles.Play();
        destroyed = true;
    }

    public bool IsDestroyed(){
        return destroyed;
    }
}
