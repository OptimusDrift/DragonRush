using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace EasyMobileInput.PlayerController
{
public class PlayerController : MonoBehaviour 
{
    [SerializeField] 
    private Joystick movementJoystick;
    [SerializeField]
    private float speed = 5f;
    private int eggCount;
    // Start is called before the first frame update
    void Start()
    {
        eggCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = movementJoystick.CurrentProcessedValue * speed;
        if(rock && deathZone){
            Destroy(gameObject);
        }
    }

    private bool rock, deathZone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            eggCount++;
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            rock = true;
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            deathZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            rock = false;
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            deathZone = false;
        }
    }
}
}