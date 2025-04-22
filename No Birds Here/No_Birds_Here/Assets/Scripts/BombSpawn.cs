using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombSpawn : MonoBehaviour
{
    public GameObject BombObject;
    public Transform[] spawnDownPoints;

    private float timeCount;
    public int spawntime;

    [SerializeField] int limitSpawnTime = 3;

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= spawntime && spawntime >= limitSpawnTime)
        {
            SpawnEnemies();
            spawntime--;
            timeCount = 0f;
        }
        if (spawntime < limitSpawnTime)
        {
            spawntime++;
        }
    }

    void SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, spawnDownPoints.Length);
        Transform spawnPoint = spawnDownPoints[spawnIndex];

        Instantiate(BombObject, spawnPoint.position, spawnPoint.rotation);

    }
}
