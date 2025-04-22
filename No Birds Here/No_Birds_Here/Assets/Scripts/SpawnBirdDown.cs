using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirdDown : MonoBehaviour
{
    public List<GameObject> EnemeisList = new List<GameObject>();
    public Transform[] spawnDownPoints;

    private float timeCount;
    public int spawntime;


    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= spawntime)
        {
            SpawnEnemies();
            timeCount = 0f;
        }
       
    }

    void SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, spawnDownPoints.Length);
        Transform spawnPoint = spawnDownPoints[spawnIndex];

        Instantiate(EnemeisList[Random.Range(0, EnemeisList.Count)], spawnPoint.position, spawnPoint.rotation);

    }

}
