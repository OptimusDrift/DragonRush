using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject script;
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
        
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = spawnPoint.position;
        gameObject.GetComponent<Collider2D>().enabled = true;
        gameObject.SetActive(false);
    }
}
