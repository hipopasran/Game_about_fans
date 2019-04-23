using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyController : MonoBehaviour {

    /*
     *  Simple enemy. Only follow to player. 
     */

    public Transform PlayerOrTarget;
    public float EnemySpeed;

    private Rigidbody2D enemyBody;
    private EventManager eventManager;

    void Awake()
    {
        Init();
    }

    void FixedUpdate()
    {
        Vector2 direction = ((Vector2)PlayerOrTarget.position - enemyBody.position).normalized;
        enemyBody.velocity = new Vector3(direction.x, direction.y, 0) * EnemySpeed;
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
