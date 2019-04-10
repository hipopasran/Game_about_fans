using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    /*
     * Script for using sounds in AudioManager.
     */

    public string Name;
    public AudioClip Clip;
    public AudioMixerGroup AudioMixerGroup;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;

    public bool Loop;

    //[HideInInspector]
    public AudioSource source;
}
