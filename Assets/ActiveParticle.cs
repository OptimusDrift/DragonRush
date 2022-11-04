using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private GameObject shadow;
    [SerializeField]
    private GameObject egg;
    public void Active()
    {
        GetComponent<Collider2D>().enabled = false;
        particle.Play();
        shadow.SetActive(false);
        egg.SetActive(false);
    }
}
