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
    [SerializeField]
    private float timeSpawn = 1f;
    [SerializeField]
    private float timeToAttack = 15f;
    [SerializeField]
    private Transform endLevel;
    void Start()
    {
        StartCoroutine(Spawn(1f));
        Physics2D.IgnoreCollision(endLevel.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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

    private int wait = 0;
    IEnumerator Wait()
    {
        if ((target.transform.position.x - gameObject.transform.position.x) > 1.5f)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed/3;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
        else if ((target.transform.position.x - gameObject.transform.position.x) < -1.5f)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * speed/3;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*-1, transform.localScale.y, transform.localScale.z);
        } else {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        wait++;
        yield return new WaitForSeconds(.3f);
        if(wait > timeToAttack){
            Attack();
            wait = 0;
        }else
        {
            StartCoroutine(Wait());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("other: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Rock"))
        {
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            if (wait <= 0)
            {
                wait = 1;
                gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                StartCoroutine(Wait());
            }
        }
        if (other.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(Spawn(timeSpawn));
        }
    }
}
