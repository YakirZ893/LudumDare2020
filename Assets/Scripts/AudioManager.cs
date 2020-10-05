using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.Assertions.Must;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public int level;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance ==null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
    }
    private void Start()
    {
        Play("Theme");
        level = SceneManager.GetActiveScene().buildIndex;
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
           
        }
           
    }



   
}
