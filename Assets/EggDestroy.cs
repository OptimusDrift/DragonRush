using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;

    public void Destroyed()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
