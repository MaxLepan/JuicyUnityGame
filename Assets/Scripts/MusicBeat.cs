using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBeat : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Light[] lights;
    [SerializeField] float minIntensity = 0.5f;
    [SerializeField] float maxIntensity = 8f;
    [SerializeField] float intensityChangeSpeed = 0.1f;
    [SerializeField] int maxSpectrum = 30;

    float intensity = 0;

    private void Start()
    {
        intensity = minIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[128];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float totaldB = 0f;

        for (int i = 0; i < maxSpectrum; i++)
        {
            totaldB += spectrum[i];
        }

        float averagedB = totaldB / maxSpectrum;
        Debug.Log("Total dB : " + totaldB + " | average dB : " + averagedB);

        if (averagedB * maxIntensity > intensity + intensityChangeSpeed)
        {
            intensity = intensity + intensityChangeSpeed;
        } else if (averagedB * maxIntensity < intensity - intensityChangeSpeed)
        {
            intensity = intensity - intensityChangeSpeed;
        } else
        {
            intensity = averagedB * maxIntensity;
        }

        if (intensity > maxIntensity)
        {
            intensity = maxIntensity;
        }
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = maxIntensity * spectrum[0];
        }
    }
}
