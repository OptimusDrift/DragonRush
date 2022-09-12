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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        transform.position += movementJoystick.CurrentProcessedValue * Time.deltaTime * 10.0f;
    }
}
}