﻿using UnityEngine;

[CreateAssetMenu(fileName = "MatchSettings", menuName = "Data/MatchSettings")]
public class MatchSettings : ScriptableObject {

    /* 
     * Data about match settings.
     * Like character skin, best score.
     */

    public Character CurrentCharacter;
    public Character CurrentEnemy;
    public Character StandartCharacterSkin;
    public Character StandartEnemySkin;
    public GameObject Coin;
    public GameObject Slice;
    public GameSettings Settings;
    public Progress Progress;

}
