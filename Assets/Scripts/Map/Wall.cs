using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] 
    private Transform deathZone;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(deathZone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
