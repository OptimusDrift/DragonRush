using System.Collections;
using System.Collections.Generic;
using EasyMobileInput.PlayerController;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private string nameState;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().SetState(nameState, time);
        }
    }
}
