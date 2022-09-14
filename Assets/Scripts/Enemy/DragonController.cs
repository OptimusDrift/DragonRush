using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private Transform target;
    void Start()
    {
        
    }
    void Update()
    {
        if (a)
        {
            Attack();
        }
        if (b)
        {
            LoadAttack();
        }
    }

    bool a = true;
    public void Attack()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
        a = false;
    }

    bool b = false;
    public void LoadAttack()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(target.transform.position.x, 0) * speed/2;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
            //a = true;
            b = true;
        }
    }
}
