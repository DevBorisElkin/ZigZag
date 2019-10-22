using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private int currentSongIndex;
    String play = "";
    public int inGameSongsAmount;

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

        fillSoundArray();
    }

    void fillSoundArray()
    {
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
            Debug.Log("Can't find a sound with name '" + name + "'");
            return;
        }
        s.source.Play();
        //if (name == "Theme_1")
        //{
        //    float svolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        //    s.source.volume = svolume;
        //}
    }

    private void Start()
    {
        int random = UnityEngine.Random.Range(1, inGameSongsAmount+1);
        setIndexAndString(random);
        Play(play);
    }

    private void Update()
    {
        Sound s = Array.Find(sounds, sound => sound.name == play);
        if (s == null)
        {
            Debug.Log("Can't find a sound with name '" + name + "'");
            return;
        }
        if (!s.source.isPlaying)
        {
            int random = 0;
            do { random = UnityEngine.Random.Range(1, 6); } while (random == currentSongIndex);
            
            if (random != currentSongIndex)
            {
                setIndexAndString(random);
            }
            Play(play);
        }
    }

    public void updateVolume(float value)
    {
        AudioSource[] sources = instance.GetComponents<AudioSource>();
        AudioSource source = sources[0];
        if (source.isPlaying)
        {
            source.volume = value;
        }
        else
        {
            Debug.Log("AudioSource is not playing");
        }
    }

    void setIndexAndString(int a)
    {
        string menu_song = "Epic_" + a;
        currentSongIndex = a; play = menu_song;
    }

    public void makeButtonClick()
    {
        int a = UnityEngine.Random.Range(1, inGameSongsAmount+1);
        switch (a)
        {
            case 1:
                Play("Button_1");
                break;
            case 2:
                Play("Button_2");
                break;
            case 3:
                Play("Button_3");
                break;
            case 4:
                Play("Button_4");
                break;
            case 5:
                Play("Button_5");
                break;
            default:
                Debug.Log("Index out of bounds: " + a);
                break;
        }
    }
    public void makeClinkSound()
    {
        int a = UnityEngine.Random.Range(1, 3);
        switch (a)
        {
            case 1:
                Play("Button_2");
                break;
            case 2:
                Play("Button_4");
                break;
            default:
                Debug.Log("Index out of bounds: " + a);
                break;
        }
    }

    public void makeCrystalSound()
    {
        int a = UnityEngine.Random.Range(1, 5);
        Play("Glass_"+a);
                
    }

    public void makeLoseSound()
    {
        Play("Whistle");
    }
}

