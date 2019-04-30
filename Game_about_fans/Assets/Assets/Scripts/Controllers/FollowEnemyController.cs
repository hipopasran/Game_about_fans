using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyController : MonoBehaviour {

    /*
     *  Simple enemy. Only follow to player. 
     */

    public GameObject Target;
    public float EnemySpeed;

    private Rigidbody2D enemyBody;
    private Vector2 moveVelocity;

    // Event manager for collision
    private EventManager eventManager;

    void Awake()
    {
        Init();
    }

    // Use for calculate direction to player
    void Update()
    {
        Vector2 direction = ((Vector2)Target.transform.position - enemyBody.position);
        moveVelocity = direction.normalized * EnemySpeed;
    }

    // Movement
    void FixedUpdate()
    {
        enemyBody.MovePosition(enemyBody.position + moveVelocity * Time.deltaTime);
    }

    // Initialization parameters of Enemy.
    private void Init()
    {
        enemyBody = this.GetComponent<Rigidbody2D>();
        eventManager = new EventManager();
    }



    // Collision with anything on game scene.
    private void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }
}
