using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;

    private AudioSource audioSource;

    private bool firstMusicEnded = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;//루프 끄고 수동 제어
        audioSource.clip = backgroundMusic1;
        audioSource.Play();

        Invoke("LoadSecondMusic", audioSource.clip.length - 10);
    }

    void LoadSecondMusic()
    {
        audioSource.clip = backgroundMusic2;
        audioSource.loop = true;
        audioSource.Play();

        firstMusicEnded = true;
    }

    void Update()
    {
        if(firstMusicEnded && !audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic1;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeScene()
    {
        audioSource.Stop();
    }
}