using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Brackeys: Introduction to AUDIO in Unity
    //https://youtu.be/6OT43pvUyfY

    public Sound[] sounds;

    public static AudioManager instance;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);


        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }

        s.source.Play();
    }
}
