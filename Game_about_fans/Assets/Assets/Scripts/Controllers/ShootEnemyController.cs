using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyController : MonoBehaviour {

    /*
     *  Enemi which follow but keeps distance and shoot.
     */

    public float Speed;
    public float StoppingDistance;
    public float RetreatDistance;
    public float BulletSpeed;
    public float TimeBtwShots;

    public GameObject Bullet;
    public GameObject Target;


    private float timeForShots;

    // Event manager for collision
    private EventManager eventManager;


    void Awake()
    {
        Init();
    }


    void Update()
    {
        var DistanceBetween = Vector2.Distance(transform.position, Target.transform.position);

        if(DistanceBetween > StoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
        }
        else if(DistanceBetween < StoppingDistance && DistanceBetween > RetreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(DistanceBetween < RetreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, -Speed * Time.deltaTime);
        }

        if(timeForShots <=0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timeForShots = TimeBtwShots;
        }
        else
        {
            timeForShots -= Time.deltaTime;
        }
        
    }

    // Initialization parameters of Enemy
    private void Init()
    {
        eventManager = new EventManager();
        //мб переделать
        Bullet.GetComponent<BulletController>().Target = Target;
        Bullet.GetComponent<BulletController>().Speed = BulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }

}
