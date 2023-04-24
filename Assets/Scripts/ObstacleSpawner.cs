using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject obstaclePrefab;
    
    
    [Header("Timers")]

    [SerializeField] float timeToSpawn = 2f;
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
        float[] spectrum = new float[256];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        Debug.Log(spectrum[0]);
        if ((spectrum[0] > beatDetectionThreshold) && (Time.time >= timeToSpawn) && (Time.time <= timeToSpawn + maxTimeBetweenWaves))
        {
            spawnObstacles();
            timeToSpawn = Time.time + minTimeBetweenWaves;
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
