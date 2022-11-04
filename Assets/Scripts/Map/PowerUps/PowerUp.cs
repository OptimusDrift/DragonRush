using System.Collections;
using System.Collections.Generic;
using EasyMobileInput.PlayerController;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float[] time;
    [SerializeField]
    private string nameState;
    [SerializeField]
    private GameObject particles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().SetState(nameState, time[PlayerPrefs.GetInt("Level" + nameState)]);
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
