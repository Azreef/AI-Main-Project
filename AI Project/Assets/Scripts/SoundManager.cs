using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    public Sounds[] sounds;

    void Awake()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            
            s.source.volume= s.volume;
      
        }
    }

    public void Play(string sound)
    {
        Sounds s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
