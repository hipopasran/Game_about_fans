using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    /*
     *  Enemy spawn logic 
     */

    public bool IsStartGame;                    //  Game is started, Start animation end

    public Transform[] UpSpawns;                //  Array for spawns where Player in top of field
    public Transform[] DownSpawns;              //  Array for spawns where Player in buttom of field

    public GameObject Player;                   //  Player for calculate wich array is need to use
    public GameObject[] EnemiesType;            //  Array of enemies

    public float TimeBTWEnemy;                  //  Time between enemies waves

    private float timeLeft;                     //  Time for next wave of enemies

    void Awake()
    {
        IsStartGame = false;
    }

    void Update()
    {
        if (IsStartGame)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    SpawnEnemy();
                }
                timeLeft = TimeBTWEnemy;
            }
        }
    }

    private void SpawnEnemy()
    {
        if(Player.transform.position.y >= 0)
        {
            Choose(UpSpawns);
        }
        else if(Player.transform.position.y < 0)
        {
            Choose(DownSpawns);
        }
        else
        {
            return;
        }
    }

    private void Choose(Transform[] spawns)
    {
        var spawnPoint = spawns[Random.Range(0, spawns.Length)];
        var enemy = EnemiesType[Random.Range(0, EnemiesType.Length)];
        Instantiate(enemy, new Vector3(spawnPoint.position.x, spawnPoint.position.y), Quaternion.identity);
    }
}
