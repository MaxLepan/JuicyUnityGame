using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawner : MonoBehaviour
{

    [SerializeField] public Transform[] spawnPoints;
    [SerializeField] public GameObject[] obstaclePrefabs;
    [SerializeField] public float minSize = 70.0f;
    [SerializeField] public float maxSize = 100.0f;
    [SerializeField] public float minHeight = 2.5f;
    [SerializeField] public float maxHeight = 5f;
    [SerializeField] float incrementObstaclePerWave = 0.1f;
    [SerializeField] public float minimumObstacleNumber = 5f;

    [Header("Timers")]

    [SerializeField] float timeToSpawn = 0f;
    [SerializeField] float minTimeBetweenWaves = 0.73f;

    float waveCount = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            waveCount++;
            int obstacleCount = (int)Mathf.Round(waveCount * incrementObstaclePerWave + minimumObstacleNumber);
            spawnScenery(obstacleCount);
            timeToSpawn = Time.time + minTimeBetweenWaves;
        }
    }

    void spawnScenery(int obstacleCount)
    {
        List<int> spawnPointIndex = new List<int>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPointIndex.Add(i);
        }

        while (spawnPointIndex.Count > obstacleCount)
        {
            spawnPointIndex.RemoveAt(Random.Range(0, spawnPointIndex.Count));
        }

        for (int i = 0; i < spawnPointIndex.Count; i++)
        {
            int randomPrefab = Random.Range(0, obstaclePrefabs.Length - 1);

            GameObject newObject = Instantiate(obstaclePrefabs[randomPrefab], spawnPoints[spawnPointIndex[i]].position, Quaternion.identity);

            float randomSize = Random.Range(minSize, maxSize);
            Vector3 randomScale = new Vector3(randomSize, randomSize, randomSize);
            newObject.transform.localScale = randomScale;

            float randomPositionY = Random.Range(minHeight, maxHeight);
            Vector3 randomPosition = new Vector3(newObject.transform.localPosition.x, randomPositionY, newObject.transform.localPosition.z);
            newObject.transform.localPosition = randomPosition;
        }
    }

}
