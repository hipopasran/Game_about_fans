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
    public Progress Progress;

    void OnEnable()
    {
        EventManager.Hited += HitManager;
    }

    void OnDisable()
    {
        EventManager.Hited -= HitManager;
    }

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

        Player.GetComponent<PlayerManager>().PlayerSpeed = GameBalance.PlayerSpeed;
    }

    // All hit between anything in Game scene here.
    private void HitManager(GameObject first, GameObject second)
    {

    }

}
