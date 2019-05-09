using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyController : MonoBehaviour {

    /*
     *  Simple enemy. Only follow to player. 
     */

    public GameObject Target;               //  Player
    public float Speed;                     //  Speed of this enemy


    private EventManager eventManager;      // Event manager for collision


    void Awake()
    {
        Init();
    }


    // Movement
    void FixedUpdate()
    {
        Move();
    }


    // Initialization parameters of Enemy.
    private void Init()
    {
        eventManager = new EventManager();
    }


    //  Moving
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }


    // Collision with anything on game scene.
    private void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }
}
