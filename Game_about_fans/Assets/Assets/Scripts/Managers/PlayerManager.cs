using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    /*
     *  Player movement and collision. 
     */

    public float PlayerSpeed;

    private TouchController touchController;
    private Rigidbody2D playerBody;
    private Vector2 moveVelocity;

    // Event manager for collision
    private EventManager eventManager;


	// Use this for initialization
	void Start () {

        playerBody = this.GetComponent<Rigidbody2D>();
        touchController = new TouchController();
        eventManager = new EventManager();
    }
	
    // Used for take Direction from TouchController
    void Update()
    {
        touchController.TouchControll();
        moveVelocity = touchController.Direction.normalized * PlayerSpeed;
    }

	// Update player position
	void FixedUpdate () {

        //touchController.TouchControll();
        //playerBody.velocity = touchController.Direction.normalized * PlayerSpeed;
        playerBody.MovePosition(playerBody.position + moveVelocity * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }
}
