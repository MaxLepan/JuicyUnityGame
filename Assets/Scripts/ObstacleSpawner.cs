using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] public Transform[] spawnPoints;
    /*
    [SerializeField] public GameObject obstaclePrefab1;
    [SerializeField] public GameObject obstaclePrefab2;
    [SerializeField] public GameObject obstaclePrefab3;
    [SerializeField] public GameObject obstaclePrefab4;
    [SerializeField] public GameObject obstaclePrefab5;
    */
    [SerializeField] public GameObject[] obstaclePrefabs;
    
    [Header("Timers")]

    [SerializeField] float timeToSpawn = 0f;
    [SerializeField] float minTimeBetweenWaves = 0.73f;
    [SerializeField] float maxTimeBetweenWaves = 0.77f;

    [Header("Audio")]

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public float beatDetectionThreshold = 0.1f;

    private void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        float[] spectrum = new float[128];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        if ((spectrum[0] > beatDetectionThreshold) && (Time.time >= timeToSpawn) && (Time.time <= timeToSpawn + maxTimeBetweenWaves))
        {
            Debug.Log("Beat");
            spawnObstacles();
            timeToSpawn = Time.time + minTimeBetweenWaves;
        }

    }

    /*
    GameObject RandomObstacle()
    {
        int randomIndex = Random.Range(0, 4);

        if (randomIndex == 0)
        {
            return obstaclePrefab1;
        } else if (randomIndex == 1)
        {
            return obstaclePrefab2;
        } else if (randomIndex == 2)
        {
            return obstaclePrefab3;
        } else if (randomIndex == 3)
        {
            return obstaclePrefab4;
        } else if (randomIndex == 4)
        {
            return obstaclePrefab5;
        } else
        {
            return obstaclePrefab5;
        }
    }*/

    void spawnObstacles()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomIndex)
            {
                //Instantiate(RandomObstacle(), spawnPoints[i].position, Quaternion.identity);
                int randomPrefab = Random.Range(0, obstaclePrefabs.Length - 1);
                Instantiate(obstaclePrefabs[randomPrefab], spawnPoints[i].position, Quaternion.identity);
            }
        }
        
    }

}
