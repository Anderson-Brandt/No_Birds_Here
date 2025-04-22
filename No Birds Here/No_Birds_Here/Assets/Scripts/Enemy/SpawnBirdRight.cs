using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirdRight : MonoBehaviour
{
    public List<GameObject> EnemeisList = new List<GameObject>();
    public Transform[] LeftSpawnPoints;

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
        int spawnIndex = Random.Range(0, LeftSpawnPoints.Length);
        Transform spawnPoint = LeftSpawnPoints[spawnIndex];

        Instantiate(EnemeisList[Random.Range(0, EnemeisList.Count)], spawnPoint.position, spawnPoint.rotation);

    }
}
