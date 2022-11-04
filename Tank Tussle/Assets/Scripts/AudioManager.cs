using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Menu")
        {
            Play("BG_MainMenu");
        }
        if (scene.name == "Game_Factory")
        {
            Play("BG_Factory");
        }
        if (scene.name == "Game_BoardWalk")
        {
            Play("BG_Boardwalk");
        }
        if (scene.name == "Game_Cafe")
        {
            Play("BG_Cafe");
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch/ 2f, s.pitch / 2f));

        s.source.Stop ();
    
    }
    public void PitchUp (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }
        s.source.pitch =  1.2f;
    }
    public void PitchDown (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
        }
        s.source.pitch = 0.5f;
    
    }
}
