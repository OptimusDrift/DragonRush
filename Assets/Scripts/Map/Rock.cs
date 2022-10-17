using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private Collider2D collision;
    [SerializeField]
    private Collider2D trigger;
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
        collision.enabled = false;
        trigger.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        particles.Play();
        destroyed = true;
        StartCoroutine("Destroyeded");
    }

    IEnumerator Destroyeded(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public bool IsDestroyed(){
        return destroyed;
    }
}
