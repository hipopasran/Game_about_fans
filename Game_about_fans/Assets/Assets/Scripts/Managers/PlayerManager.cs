using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float PlayerSpeed;

    private TouchController touchController;
    private Rigidbody2D playerBody;


	// Use this for initialization
	void Start () {

        playerBody = this.GetComponent<Rigidbody2D>();
        touchController = new TouchController();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        touchController.TouchControll();
        playerBody.velocity = touchController.Direction * PlayerSpeed;
	}
}
