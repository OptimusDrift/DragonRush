using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
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
        if ((target.transform.position.x - gameObject.transform.position.x) > 1.5f)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed/2;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
        else if ((target.transform.position.x - gameObject.transform.position.x) < -1.5f)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * speed/2;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*-1, transform.localScale.y, transform.localScale.z);
        } else {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        wait++;
        yield return new WaitForSeconds(.3f);
        if(wait > 13){
            Attack();
            wait = 0;
        }else
        {
            StartCoroutine(Wait());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (wait <= 0)
            {
                StartCoroutine(Wait());
            }
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(Spawn(1f));
        }
    }
}
