using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField]
        private GameObject options;
        //private string[] states = {"estadoDuplicarCantidadDeHuevos","estadoCascoRompePiedras","estadoVidaExtra"};
        private int playerLives = 0;
        [SerializeField]
        private GameObject hudDuplicarCantidadDeHuevos;
        [SerializeField]
        private GameObject hudCascoRompePiedras;
        [SerializeField]
        private GameObject hudVidaExtra;
        [SerializeField]
        private float safeTime = 1f;
        [SerializeField]
        private GameObject helmet;
        [SerializeField]
        private GameObject save;
        private bool isSafe = false;
        private void Start()
        {
            actualSpeed = totalSpeed;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (playerLives <= 0)
            {
                hudVidaExtra.SetActive(false);
            }
            helmet.SetActive(hudCascoRompePiedras.activeSelf);
            if (movementJoystick.CurrentProcessedValue.y < 0)
            {
                gameObject.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(movementJoystick.CurrentProcessedValue.x * actualSpeed, movementJoystick.CurrentProcessedValue.y * actualSpeed * 2);
            }
            else
            {
                gameObject.transform.GetComponent<Rigidbody2D>().velocity = movementJoystick.CurrentProcessedValue * actualSpeed;
            }
            FlipPlayer();
            if (rock && deathZone)
            {
                if (!isSafe)
                {
                    PlayerDeath();
                }
            }
        }
        public void PlayerDeath()
        {
            if (playerLives > 0)
            {
                playerLives--;
                StartCoroutine(SafeTime());
            }
            else
            {
                options.GetComponent<Options>().Vibrate(500);
                gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
                shadow.enabled = false;
                save.GetComponent<SaveGame>().AddEgg(egg.GetComponent<Egg>().eggCount);
                gameOver.SetActive(true);
                gameOver.GetComponent<GameOver>().StopGame();
            }
        }
        IEnumerator SafeTime()
        {
            isSafe = true;
            yield return new WaitForSeconds(safeTime);
            isSafe = false;
        }
        private void FlipPlayer()
        {
            if (movementJoystick.CurrentProcessedValue.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (movementJoystick.CurrentProcessedValue.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            }
        }

        private bool rock, deathZone;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                StartCoroutine(AddEgg(other));
            }
            if (other.gameObject.CompareTag("Rock"))
            {
                rock = true;
            }
            if (other.gameObject.CompareTag("DeathZone"))
            {
                deathZone = true;
            }
            if (other.gameObject.CompareTag("Dragon") || other.gameObject.CompareTag("DragonFire"))
            {
                PlayerDeath();
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Slow"))
            {
                actualSpeed = totalSpeed / slow;
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
        IEnumerator AddEgg(Collider2D other)
        {
            egg.GetComponent<Egg>().AddEgg(hudDuplicarCantidadDeHuevos.activeSelf);
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<Animation>().Stop();
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.4f);
            Destroy(other.gameObject);
            /*eggCount++;
            var c = Instantiate(egg, new Vector3(eggCount * 0.5f, 0, 0), Quaternion.identity);
            c.GetComponent<HingeJoint2D>().connectedBody = gameObject.transform.GetComponent<Rigidbody2D>();
            c.transform.parent = gameObject.transform;*/
        }

        public void SetState(string state, float time)
        {
            switch (state)
            {
                case "DobleEgg":
                    StartCoroutine(State(hudDuplicarCantidadDeHuevos, time));
                    break;
                case "Helmet":
                    StartCoroutine(State(hudCascoRompePiedras, time));
                    break;
                case "ExtraLive":
                    playerLives = (int)time;
                    hudVidaExtra.SetActive(true);
                    break;
            }
        }

        IEnumerator State(GameObject hud, float time)
        {
            hud.SetActive(true);
            yield return new WaitForSeconds(time);
            hud.SetActive(false);
        }
    }
}