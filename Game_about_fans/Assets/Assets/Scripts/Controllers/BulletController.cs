using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    /*
     * Logic for Shooting enemy bullet
     */

    public float Speed;
    public float ExplosionRadius;       //  Radius of explosion
    public float ExplosionForce;        //  Explosion power
    public float RadiusNearTarget;      //  Distance for shooting at the area
    public GameObject Target;           //  Player
    public GameObject ExplosionEffect;  //  Effect after bullet explosion
    public int PlayerLayer;             //  Player Layer for bullet explosions
    public int EnemiesLayer;            //  Enemies Layer with interactable units 

    private Vector2 target;             //  Value for target of bullet
    private EventManager eventManager;  //  Event manager for handling collisions


    // Use this for initialization
    void Start ()
    {
        eventManager = new EventManager();
        target = CalculateTarget(Target.transform, RadiusNearTarget);	
	}
	
    void Update()
    {
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Explode();
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        	
	}

    private void Explode()
    {
        if (ExplosionEffect != null)
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);
        }

        int a = LayerMask.GetMask(LayerMask.LayerToName(PlayerLayer), LayerMask.LayerToName(EnemiesLayer));
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius, a);

        foreach(Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 resultForce = CalculateExplosionForce(this.transform.position, collider.transform.position);
                rb.AddForce(resultForce, ForceMode2D.Impulse);

            }
            else
            {
                continue;
            }
        }

        DestroyBullet();
    }

    //  Shooting at the area
    private Vector2 CalculateTarget(Transform target, float areaRadius)
    {
        Vector2 resultTarget = new Vector2(target.position.x + Random.Range(-areaRadius, areaRadius), target.position.y + Random.Range(-areaRadius, areaRadius));
        return resultTarget;
    }

    //  Calculate force of explosion
    private Vector2 CalculateExplosionForce(Vector2 first, Vector2 second)
    {

        Vector2 distance = (second - first);
        float force = (ExplosionRadius - Vector2.Distance(first, second))/ExplosionRadius;

        Vector2 result = distance * force * ExplosionForce;

        return result;
    }

    // Destroy
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        eventManager.OnHited(this.gameObject, other.gameObject);
    }
}
