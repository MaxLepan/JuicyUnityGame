using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject obstaclePrefab;
    
    /*
    [Header("Timers")]

    [SerializeField] float timeToSpawn = 2f;
    [SerializeField] float minTimeBetweenWaves = 0.73f;
    [SerializeField] float maxTimeBetweenWaves = 0.77f;

    [Header("Audio")]

    //[SerializeField] public float sensitivity = 100.0f;
    [SerializeField] public float thresholdDB = 0.0f;*/
    [SerializeField] public AudioSource audioSource;

    [SerializeField] public float startTime1 = 0.1f;
    [SerializeField] public float endTime1 = 15.0f;
    [SerializeField] public float startTime2 = 15.1f;
    [SerializeField] public float endTime2 = 78.5f;
    [SerializeField] public float startTime3 = 78.6f;
    public float endTime3;

    private float level1;
    private float level2;
    private float level3;

    public float updateInterval = 0.1f;
    private float[] samples;
    private float db;
    private int bufferSize = 16384;
    int lastSampleIndex = 0;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = (AudioClip)Resources.Load("Songpack/Believe");
        audioSource.Play();

        endTime3 = audioSource.clip.length;

        samples = new float[bufferSize];

        audioSource.clip.GetData(samples, lastSampleIndex);
        level1 = CalculateLevel(samples, startTime1, endTime1);
        lastSampleIndex += samples.Length;

        audioSource.clip.GetData(samples, lastSampleIndex);
        level2 = CalculateLevel(samples, startTime2, endTime2);
        lastSampleIndex += samples.Length;

        audioSource.clip.GetData(samples, lastSampleIndex);
        level3 = CalculateLevel(samples, startTime3, endTime3);

        Debug.Log("Level 1: " + level1);
        Debug.Log("Level 2: " + level2);
        Debug.Log("Level 3: " + level3);
    }

    
    private void Update()
    {
        /*
        if (Time.time >= timeToSpawn)
        {
            spawnObstacles();
            timeToSpawn = Time.time + timeBetweenWaves;
        }*/
        /*
        // Détection du seuil de détection des niveaux de décibels
        if ((averageVolumeDB > thresholdDB) && ((Time.time >= timeToSpawn) && (Time.time <= timeToSpawn + maxTimeBetweenWaves)))
        {
            spawnObstacles();
            timeToSpawn = Time.time + minTimeBetweenWaves;
        }*/
        /*
        if (Time.timeSinceLevelLoad < updateInterval)
        {
            return; // attendez l'intervalle de temps pour mettre à jour le niveau de dB
        }

        audioSource.GetOutputData(samples, 0); // obtenir les échantillons audio actuels
        float sum = 0;
        int count = Mathf.Min(samples.Length, bufferSize);
        for (int i = 0; i < count; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        float rms = Mathf.Sqrt(sum / count);
        db = 20 * Mathf.Log10(rms); // calculer le niveau de dB en temps réel

        Debug.Log("Niveau de dB actuel : " + db);*/

    }

    float CalculateLevel(float[] samples, float startTime, float endTime)
    {
        int startSample = (int)(startTime * audioSource.clip.frequency);
        int endSample = (int)(endTime * audioSource.clip.frequency);

        startSample = Mathf.Clamp(startSample, 0, samples.Length);
        endSample = Mathf.Clamp(endSample, 0, samples.Length);

        float sum = 0;
        for (int i = startSample; i < endSample; i++)
        {
            if (i >= 0 && i < samples.Length)
            {
                sum += Mathf.Abs(samples[i]);
            }
        }

        float rms = Mathf.Sqrt(sum / (endSample - startSample));
        return 20 * Mathf.Log10(rms);
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
