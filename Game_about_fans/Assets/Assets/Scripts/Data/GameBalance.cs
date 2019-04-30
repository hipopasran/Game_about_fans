using UnityEngine;

[CreateAssetMenu(fileName = "GameBalance", menuName = "Data/GameBalance")]
public class GameBalance : ScriptableObject {

    /* 
     * Data for balance settings
     */

    // General
    [Header("General")]
    public float PlayerSpeed;   // Player speed
    public float EnemySpeed;    // All enemy speed
    
    //Shoting Enemy
    [Header("Shooting Enemy")]
    public float BulletSpeed;           // Bullet speed of Shooting enemy
    public float StoppingDistance;      // Stopping distance of Shooting enemy
    public float RetreatDistance;       // Retreat distance of Shooting enemy
    public float TimeBtwShots;          // Time between shots of Shooting enemy

}
