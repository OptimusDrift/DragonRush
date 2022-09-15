using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform spawnPoint;
    void Start()
    {
        StartCoroutine(Spawn(1f));
    }

    IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        gameObject.transform.position = spawnPoint.position;
    }

    void Update()
    {

    }

    public void Attack()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
    }
    IEnumerator LoadAttack()
    {
        yield return new WaitForSeconds(5f);
        Attack();
    }
    private int wait = 0;
    IEnumerator Wait()
    {
        wait++;
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(target.transform.position.x, 0) * speed/2;
        yield return new WaitForSeconds(1);
        if(wait > 5){
            Attack();
            wait = 0;
        }else
        {
            StartCoroutine(Wait());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine(Wait());
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(Spawn(1f));
        }
    }
}
