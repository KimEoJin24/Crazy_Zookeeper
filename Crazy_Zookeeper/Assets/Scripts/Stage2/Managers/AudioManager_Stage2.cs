using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Stage2 : MonoBehaviour
{
    public static AudioManager_Stage2 instance;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume; 
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance; 
    [SerializeField][Range(0f, 1f)] private float musicVolume;


    private void Awake()
    {
        instance = this; }
    }
}
