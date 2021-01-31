using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static Music instance;
    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();

        if(instance)
        {
            if(instance.audio.clip != audio.clip)
            {
                instance.audio.clip = audio.clip;
                instance.audio.Play();
            }

            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
