using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public AudioMixerGroup Music;
    public AudioMixerGroup Sound;
    public GameSettings Setting;

    public static AudioManager instance;

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

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.outputAudioMixerGroup = s.AudioMixerGroup;

            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }

    void Start()
    {
        statusCheck();
        Play("Theme");

    }

    void Update()
    {
        statusCheck();
    }

    private void statusCheck()
    {
        if (Setting.Music)
        {
            Music.audioMixer.SetFloat("MusicVolume", 0);
        }
        else
        {
            Music.audioMixer.SetFloat("MusicVolume", -80);
        }

        if (Setting.Effect)
        {
            Sound.audioMixer.SetFloat("SoundVolume", 0);
        }
        else
        {
            Sound.audioMixer.SetFloat("SoundVolume", -80);
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else
        {
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else
        {
            s.source.Stop();
        }
    }
}
