using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour {

    /*
     *  All Gameplay here. Also initialization of map. 
     */
    
    [Header("Player")]
    public GameObject Player;
    [Header("Enemies")]
    public GameObject[] Enemies;
    public GameObject FollowingEnemy;
    public GameObject ShootingEnemy;
    [Header("Data")]
    public MatchSettings MatchSettings;
    public GameBalance GameBalance;
    public Progress Progress;


    public GameObject SpawnManager;

    //  Variables to initialize player and enemy parameters via script
    private PlayerManager player;
    private EnemySpawnManager spawnManagerSettings;
  //  private FollowEnemyController enemy1;
  //  private ShootEnemyController enemy2;

    //  Parameters for collision handling, copy tracking
    private Dictionary<Vector3, Vector3> listOfCollisions;

    // For Start animation
    private Animator anim;


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
        anim.Play("StartGame");
    }


    // Initialization skins of characters and enemies
    private void Init()
    {
        //  Init Parameters for collisions handling
        listOfCollisions = new Dictionary<Vector3, Vector3>();

        //  Init Player params
        player = Player.GetComponent<PlayerManager>();
        player.PlayerSpeed = GameBalance.PlayerSpeed;

        //  Init Following enemy params
        var enemy1 = Enemies[0].GetComponent<FollowEnemyController>();
        enemy1.Target = Player;
        enemy1.Speed = GameBalance.EnemySpeed;

        //  Init Shooting Enemy params
        var enemy2 = Enemies[1].GetComponent<ShootEnemyController>();
        enemy2.Target = Player;
        enemy2.Speed = GameBalance.EnemySpeed;
        enemy2.StoppingDistance = GameBalance.StoppingDistance;
        enemy2.TimeBtwShots = GameBalance.TimeBtwShots;
        enemy2.RetreatDistance = GameBalance.RetreatDistance;
        enemy2.BulletSpeed = GameBalance.BulletSpeed;
        enemy2.PlayerLayer = GameBalance.PlayerLayer;
        enemy2.EnemiesLayer = GameBalance.EnemiesLayer;
        

        // Init Charecter skin
        if (MatchSettings.CurrentCharacter != null)
        {
            Player.GetComponent<SpriteRenderer>().sprite = MatchSettings.CurrentCharacter.Sprite;
        }
        else
        {
            Player.GetComponent<SpriteRenderer>().sprite = MatchSettings.StandartCharacterSkin.Sprite;
        }

        // Init Enemies skins
        if (MatchSettings.CurrentEnemyPackage != null)
        {
            Enemies[0].GetComponent<SpriteRenderer>().sprite = MatchSettings.CurrentEnemyPackage.FollwingEnemy.Sprite;
            Enemies[1].GetComponent<SpriteRenderer>().sprite = MatchSettings.CurrentEnemyPackage.ShootingEnemy.Sprite;
        }
        else
        {
            Enemies[0].GetComponent<SpriteRenderer>().sprite = MatchSettings.StandartEnemyPackage.FollwingEnemy.Sprite;
            Enemies[1].GetComponent<SpriteRenderer>().sprite = MatchSettings.StandartEnemyPackage.ShootingEnemy.Sprite;
        }

        //  Init Scene Animator
        anim = GetComponent<Animator>();

        //  Init Enemies spawn manager
        spawnManagerSettings = SpawnManager.GetComponent<EnemySpawnManager>();
        spawnManagerSettings.Player = Player;
        spawnManagerSettings.TimeBTWEnemy = GameBalance.TimeBTWEnemies;
        spawnManagerSettings.EnemiesType = new GameObject[Enemies.Length];
        for(int i = 0; i < Enemies.Length; i++)
        {
            spawnManagerSettings.EnemiesType[i] = Enemies[i];
        }
        


    }

    //  All hit between anything in Game scene here.
    private void HitManager(GameObject first, GameObject second)
    {
        
        //  Key is center of collision. It will kill copy of collisions.

        Vector3 centerOfCollision = (first.transform.position + second.transform.position) / 2;

        if(listOfCollisions.ContainsKey(centerOfCollision))
        {
            listOfCollisions.Remove(centerOfCollision);
        }
        else
        {
            listOfCollisions.Add(centerOfCollision, centerOfCollision);

            if(first.tag == "Player")
            {
                if(second.tag == "Enemy")
                {
                    GameOver();
                }
                else if(second.tag == "Coin")
                {
                    Destroy(second);
                    Progress.Cash++;
                }
                else
                {
                    return;
                }
            }
            else if(first.tag == "Enemy")
            {
                if(second.tag == "Player")
                {
                    GameOver();
                }
                else if(second.tag == "Coin")
                {
                    Destroy(second);
                }
                else if(second.tag == "Enemy")
                {
                    if (first.transform.parent != second.transform && second.transform.parent != first.transform)
                    {
                        Destroy(first);
                        Destroy(second);
                        Instantiate(MatchSettings.Coin, centerOfCollision, Quaternion.identity);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else if(first.tag == "Coin")
            {
                if(second.tag == "Player")
                {
                    Destroy(first);
                    Progress.Cash++;
                }
                else if(second.tag == "Enemy")
                {
                    Destroy(first);
                }
                else
                {
                    return;
                }
            }
            else
            {
                listOfCollisions.Remove(centerOfCollision);
                return;
            }
        }
    }

    private void StartGame()
    {
        Debug.Log("Stop");
        anim.enabled = false;
        spawnManagerSettings.IsStartGame = true;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
