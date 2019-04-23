using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    /*
     *  All Gameplay here. Also initialization of map. 
     */

    public GameObject Player;
    public GameObject[] Enemy;
    public MatchSettings MatchSettings;
    public GameBalance GameBalance;


    public void Awake()
    {
        Init();
    }


    // Initialization skins of characters and enemies
    private void Init()
    {
        // Charecter
        if (MatchSettings.CurrentCharacter != null)
        {
            Player.GetComponent<SpriteRenderer>().sprite = MatchSettings.CurrentCharacter.Sprite;
        }
        else
        {
            Player.GetComponent<SpriteRenderer>().sprite = MatchSettings.StandartCharacterSkin.Sprite;
        }

        // Enemies
        if (MatchSettings.StandartEnemySkin != null)
        {
            foreach (var enemy in Enemy)
            {
                enemy.GetComponent<SpriteRenderer>().sprite = MatchSettings.CurrentEnemy.Sprite;
            }
        }
        else
        {
            foreach(var enemy in Enemy)
            {
                enemy.GetComponent<SpriteRenderer>().sprite = MatchSettings.CurrentCharacter.Sprite;
            }
        }
    }

}
