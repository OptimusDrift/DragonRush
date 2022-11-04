using System.Collections;
using System.Collections.Generic;
using EasyMobileInput.PlayerController;
using UnityEngine;

public class EggDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Egg");
            Instantiate(particle, transform.position, Quaternion.identity);
            StartCoroutine(other.gameObject.GetComponent<PlayerController>().AddEgg(gameObject.GetComponent<Collider2D>()));
            Destroy(gameObject);
        }
    }
}
