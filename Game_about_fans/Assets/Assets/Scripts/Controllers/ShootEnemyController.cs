using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyController : MonoBehaviour {

    /*
     *  Enemi which follow but keeps distance and shoot.
     */

    public float Speed;                 //  Speed of this enemy
    public float StoppingDistance;      //  Distance between enemy and player for stop
    public float RetreatDistance;       //  Distance between enemy and player for retreat
    public float BulletSpeed;           //  Speed of the bullet
    public float TimeBtwShots;          //  Time between shots

    public int PlayerLayer;             //  Layer for bullet explosions
    public int EnemiesLayer;            //  Layer for bullet explosion

    public GameObject Bullet;           //  Bullet prefab
    public GameObject Target;           //  Player

    private float timeForShots;         //  Value for timer between shot

    // state status
    private bool isFollowing;
    private bool isRetreating;
    private bool isStopping;
    private bool isShooting; 

    private BulletController bullet;    //  Variable for buller params init

    private EventManager eventManager;  //  Event manager for collision


    void Awake()
    {
        Init();
    }


    void Update()
    {
        var DistanceBetween = Vector2.Distance(transform.position, Target.transform.position);

        if(DistanceBetween > StoppingDistance)
        {
            isStopping = false;
            isRetreating = false;
            isFollowing = true;
            
        }
        else if(DistanceBetween < StoppingDistance && DistanceBetween > RetreatDistance)
        {
            isFollowing = false;
            isRetreating = false;
            isStopping = true;
        }
        else if(DistanceBetween < RetreatDistance)
        {
            isStopping = false;
            isFollowing = false;
            isRetreating = true;
        }

        if(timeForShots <=0)
        {
            isShooting = true;
        }
        else
        {
            timeForShots -= Time.deltaTime;
        }
        
    }

    // /using for Movement and Shooting
    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    // Initialization parameters of Enemy
    private void Init()
    {
        eventManager = new EventManager();

        //  Bullet params init
        bullet = Bullet.GetComponent<BulletController>();

        bullet.Target = Target;
        bullet.Speed = BulletSpeed;
        bullet.PlayerLayer = PlayerLayer;
        bullet.EnemiesLayer = EnemiesLayer;

    }

    //  Moving
    private void Move()
    {
        if(isFollowing)
        {
            Follow();
        }
        else if(isRetreating)
        {
            Retreat();
        }
        else if(isStopping)
        {
            Stop();
        }
        else
        {
            return;
        }
    }

    //  Following
    private void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

    //  Retreating
    private void Retreat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, -Speed * Time.deltaTime);
    }

    //  Stopping
    private void Stop()
    {
        transform.position = this.transform.position;
    }

    //  Shooting
    private void Shoot()
    {
        if (isShooting)
        {
            isShooting = false;
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timeForShots = TimeBtwShots;
        }
        else
        {
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }



}
