using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float Speed;
    public GameObject Target;

    private Vector2 target;

    // Event manager for collision
    private EventManager eventManager;

    // Use this for initialization
    void Start ()
    {
        eventManager = new EventManager();
        target = new Vector2(Target.transform.position.x, Target.transform.position.y);	
	}
	
    void Update()
    {
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        	
	}

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }
}
