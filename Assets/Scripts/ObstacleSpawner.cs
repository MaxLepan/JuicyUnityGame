using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject obstaclePrefab;

    [Header("Timers")]

    [SerializeField] float timeToSpawn = 2f;
    [SerializeField] float timeBetweenWaves = 1f;

    private void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            spawnObstacles();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void spawnObstacles()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomIndex)
            {
                Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

}
