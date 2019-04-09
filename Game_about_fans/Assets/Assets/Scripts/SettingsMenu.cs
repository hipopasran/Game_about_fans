using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {

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
        //music.isOn = !music.isOn;
        GameSettings.Music = music.isOn;
    }

    public void OnSoundsButtonClick()
    {
        //sounds.isOn = !sounds.isOn;
        GameSettings.Effect = sounds.isOn;
    }
	
}
