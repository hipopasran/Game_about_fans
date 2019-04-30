using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPackage", menuName = "Data/EnemyPackage")]
public class EnemyPackage : ScriptableObject {

    /*
     *  Enemy sprite packages 
     */
    [Header("Simple enemy")]
    public Character FollwingEnemy;

    [Header("Shooting enemy")]
    public Character ShootingEnemy;
}
