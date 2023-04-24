using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] public Transform[] spawnPoints;
    [SerializeField] public GameObject[] obstaclePrefabs;
    [SerializeField] public float minSize = 70.0f;
    [SerializeField] public float maxSize = 100.0f;
    [SerializeField] public float minimumObstacleNumber = 5f;
    
    [Header("Timers")]

    [SerializeField] float timeToSpawn = 0f;
    [SerializeField] float minTimeBetweenWaves = 0.73f;
    [SerializeField] float incrementObstaclePerWave = 0.1f;

    [Header("Audio")]

    [SerializeField] public AudioSource audioSource;

    float waveCount = 0f;

    private void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            waveCount++;
            int obstacleCount = (int)Mathf.Round(waveCount * incrementObstaclePerWave + minimumObstacleNumber);
            spawnObstacles(obstacleCount);
            timeToSpawn = Time.time + minTimeBetweenWaves;
        }

    }

    void spawnObstacles(int obstacleCount)
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
            float randomSize = Random.Range(minSize, maxSize);
            Vector3 randomScale = new Vector3(randomSize, randomSize, randomSize);
            Instantiate(obstaclePrefabs[randomPrefab], spawnPoints[spawnPointIndex[i]].position, Quaternion.identity).transform.localScale = randomScale;
        }
        
    }

}
