using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsController : MonoBehaviour {

    /* 
     * This is settings controller. Here you can work with all settings.
     * All things what you need in settings menu you can write here.
     * Also here is code for settings toggle or buttons.  
     */

    public GameObject MusicToogle;
    public GameObject SoundsToogle;
    public GameSettings GameSettings;

    private Toggle sounds;
    private Toggle music;

    void Awake()
    {
        sounds = SoundsToogle.GetComponent<Toggle>();
        music = MusicToogle.GetComponent<Toggle>();

        if(GameSettings.Music)
        {
            music.isOn = true;
        }
        else
        {
            music.isOn = false;
        }

        if(GameSettings.Effect)
        {
            sounds.isOn = true;
        }
        else
        {
            sounds.isOn = false;
        }
    }

    public void OnMusicButtonClick()
    {
        GameSettings.Music = music.isOn;
    }

    public void OnSoundsButtonClick()
    {
        GameSettings.Effect = sounds.isOn;
    }
	
}
