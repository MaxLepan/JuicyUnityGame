using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip[] musics;
    [SerializeField] public AudioSource audioSource;
    private int currentIndex = -1;

    void Start()
    {
        PlayRandomMusic();
    }

    void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, musics.Length);
        while (randomIndex == currentIndex)
        {
            randomIndex = Random.Range(0, musics.Length);
        }
        currentIndex = randomIndex;
        audioSource.clip = musics[currentIndex];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }
}
