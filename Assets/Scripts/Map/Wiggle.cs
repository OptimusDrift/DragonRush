using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour, IWiggle
{
    [SerializeField]
    private float wiggleSpeed;
    [SerializeField]
    private float wiggleAmount;
    [SerializeField]
    private float wiggleTime;

    private bool isWiggling = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }
    void Update()
    {
        if (isWiggling)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-1 * wiggleAmount, wiggleAmount) * Time.deltaTime,  transform.position.y, transform.position.z);
        }
    }

    public void Wiggles(){
        isWiggling = true;
        StartCoroutine(WiggleWall());
    }

    IEnumerator WiggleWall()
    {
        yield return new WaitForSeconds(wiggleTime);
        isWiggling = false;
        transform.position = new Vector3(originalPosition.x, transform.position.y, transform.position.z);
    }
}
