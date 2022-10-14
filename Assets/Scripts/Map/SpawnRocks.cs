using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    [SerializeField]
    private GameObject[] rocks;
    [SerializeField]
    private GameObject[] slow;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private int limitSpawn = 3;
    [SerializeField]
    private float minTime = 1.5f;
    [SerializeField]
    private float maxTime = 3f;
    [SerializeField]
    private GameObject eventManager;
    private List<GameObject> instantiatedRocks;
    private bool isSpawn = false;
    private bool isStart = false;
    void Start()
    {
        instantiatedRocks = new List<GameObject>();
    }

    void Update()
    {
        if (!isSpawn && isStart)
        {
            StartCoroutine(SpawnRock(Random.Range(minTime, maxTime)));
        }
    }

    IEnumerator SpawnRock(float time)
    {
        isSpawn = true;
        yield return new WaitForSeconds(time);
        var x = Instantiate(rocks[Random.Range(0, rocks.Length)], spawnPoint.position, Quaternion.identity);

        foreach (var item in x.GetComponentsInChildren<Animator>())
        {
            try
            {
                item.SetInteger("LevelCount", eventManager.GetComponent<EventManager>().level);
                item.SetInteger("TipoObstaculo", Random.Range(0, 3));
            }
            catch (System.Exception)
            {
            }
        }
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

    public void Play(){
        isStart = true;
    }

    public void updateTime(float min, float max)
    {
        minTime = min;
        maxTime = max;
    }
}
