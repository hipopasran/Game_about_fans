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
                SpawnEnemy();
                timeLeft = TimeBTWEnemy;
            }
        }
    }

    private void SpawnEnemy()
    {

        // Take current spawns 
        var arrayOfSpawns = ChooseSide();

        // Make new array for random choise
        Transform[] spawns = new Transform[arrayOfSpawns.Length];
        for (int i = 0; i < spawns.Length; i++)
        {
            spawns[i] = arrayOfSpawns[i];
        }

        // Choice
        for (int i = 0; i < 2; i++)
        {
            // Choose unic spawn point
            int randomPoint = Random.Range(0, spawns.Length - i);
            var spawnPoint = spawns[randomPoint];
            spawns[randomPoint] = spawns[spawns.Length - 1 - i];

            // Choose enemy
            var enemy = EnemiesType[Random.Range(0, EnemiesType.Length)];

            // Spawn
            Instantiate(enemy, new Vector3(spawnPoint.position.x, spawnPoint.position.y), Quaternion.identity);
        }
    }

    private Transform[] ChooseSide()
    {
        if (Player.transform.position.y >= 0)
        {
            return UpSpawns;
        }
        else if (Player.transform.position.y < 0)
        {
            return DownSpawns;
        }
        else
        {
            return new Transform[] {};
        }

    }
}
