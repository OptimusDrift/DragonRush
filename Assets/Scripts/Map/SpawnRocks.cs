using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private int limitSpawn = 3;
    [SerializeField]
    private float minTime = 1.5f;
    [SerializeField]
    private float maxTime = 3f;
    private List<GameObject> instantiatedRocks;
    private bool isSpawn = false;
    void Start()
    {
        instantiatedRocks = new List<GameObject>();
    }

    void Update()
    {
        if (!isSpawn)
        {
            StartCoroutine(SpawnRock(Random.Range(minTime, maxTime)));
        }
    }

    IEnumerator SpawnRock(float time)
    {
        isSpawn = true;
        yield return new WaitForSeconds(time);
        Instantiate(rocks[Random.Range(0, rocks.Length)], spawnPoint.position, Quaternion.identity);
        /*if (instantiatedRocks.Count < limitSpawn)
        {
            instantiatedRocks.Add(Instantiate(rocks[Random.Range(0, rocks.Length)], spawnPoint.position, Quaternion.identity));
        }else
        {
            instantiatedRocks.Sort();
            instantiatedRocks[0].SetActive(true);
            instantiatedRocks.RemoveAt(0);
        }*/
        isSpawn = false;
    }

    public void NewElement(GameObject g)
    {
        //instantiatedRocks.Add(g);
        
    }

    public void updateTime(float min, float max)
    {
        minTime = min;
        maxTime = max;
    }
}
