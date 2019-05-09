using UnityEngine;

[CreateAssetMenu(fileName = "GameBalance", menuName = "Data/GameBalance")]
public class GameBalance : ScriptableObject {

    /* 
     * Data for balance settings
     */

    //  General
    [Header("General")]
    public float PlayerSpeed;           //  Player speed
    public float EnemySpeed;            //  All enemy speed
    public float TimeBTWEnemies;        //  Time between enemies waves
    
    //  Shooting Enemy
    [Header("Shooting Enemy")]
    public float StoppingDistance;      //  Stopping distance of Shooting enemy
    public float RetreatDistance;       //  Retreat distance of Shooting enemy
    public float TimeBtwShots;          //  Time between shots of Shooting enemy

    //  Bullet of sho0ting enemy
    [Header("Bullet of shooting enemy")]
    public int PlayerLayer;             //  Player Layer for bullet explosion
    public int EnemiesLayer;            //  Enemies Layer for bullet explosion
    public float BulletSpeed;           //  Bullet speed of Shooting enemy
    public float ExplosionRadius;       //  Explosion radius
    public float ExplosionForce;        //  Explosion power
    public float RadiusNearTarget;      //  Distance for shooting at the area
}
