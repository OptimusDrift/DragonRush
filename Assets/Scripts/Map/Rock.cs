﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] 
    private GameObject deathZone;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(deathZone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
