using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
