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
        Destroy(collision);
        Destroy(trigger);
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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dragon"))
        {
            if (!IsDestroyed())
            {
                if (other.gameObject.GetComponent<DragonController>().dragon.GetInteger("dragonState") >= 1)
                {
                    other.gameObject.GetComponent<DragonController>().options.GetComponent<Options>().Vibrate(50);
                    other.gameObject.GetComponent<DragonController>().wall.GetComponent<IWiggle>().Wiggles();
                }
            }
            Destroyed();
        }
        if (other.gameObject.CompareTag("DragonAttack"))
        {
            Destroyed();
        }
    }
}
