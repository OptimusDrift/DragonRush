using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace EasyMobileInput.PlayerController
{
public class PlayerController : MonoBehaviour 
{
    [SerializeField] 
    private Joystick movementJoystick;
    [SerializeField]
    private float totalSpeed = 5f;
    [SerializeField]
    private float slow = 2;
    private float actualSpeed;
    [SerializeField]
    private SpriteRenderer shadow;
    [SerializeField]
    private GameObject egg;
    [SerializeField] 
    private GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        actualSpeed = totalSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick.CurrentProcessedValue.y < 0){
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(movementJoystick.CurrentProcessedValue.x* actualSpeed, movementJoystick.CurrentProcessedValue.y * actualSpeed * 2) ;
        }else
        {
            gameObject.transform.GetComponent<Rigidbody2D>().velocity = movementJoystick.CurrentProcessedValue * actualSpeed;
        }
        FlipPlayer();
        if(rock && deathZone){
            PlayerDeath();
        }
    }
    public void PlayerDeath(){
        Vibration.Vibrate(500);
        gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
        shadow.enabled = false;
        gameOver.SetActive(true);
        gameOver.GetComponent<GameOver>().StopGame();
    }
        private void FlipPlayer()
    {
        if (movementJoystick.CurrentProcessedValue.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movementJoystick.CurrentProcessedValue.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*-1, transform.localScale.y, transform.localScale.z);
        }
    }

    private bool rock, deathZone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            AddEgg();
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            rock = true;
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            deathZone = true;
        }
        if (other.gameObject.CompareTag("Dragon"))
        {
            PlayerDeath();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            actualSpeed = totalSpeed/slow;
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
        if (other.gameObject.CompareTag("Slow"))
        {
            actualSpeed = totalSpeed;
        }
    }
    private void AddEgg(){
        egg.GetComponent<Egg>().AddEgg();
        /*eggCount++;
        var c = Instantiate(egg, new Vector3(eggCount * 0.5f, 0, 0), Quaternion.identity);
        c.GetComponent<HingeJoint2D>().connectedBody = gameObject.transform.GetComponent<Rigidbody2D>();
        c.transform.parent = gameObject.transform;*/
    }
}
}