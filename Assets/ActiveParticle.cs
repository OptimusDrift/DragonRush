using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveParticle : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    private void OnDestroy()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
