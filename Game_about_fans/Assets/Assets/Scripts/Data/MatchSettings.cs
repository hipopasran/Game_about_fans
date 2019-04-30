using UnityEngine;

[CreateAssetMenu(fileName = "MatchSettings", menuName = "Data/MatchSettings")]
public class MatchSettings : ScriptableObject {

    /* 
     * Data about match settings.
     * Like character skin, best score.
     */
    [Header("Current skins")]
    public Character CurrentCharacter;
    public EnemyPackage CurrentEnemyPackage;

    [Header("Standart skins")]
    public Character StandartCharacterSkin;
    public EnemyPackage StandartEnemyPackage;

    public GameObject Coin;
    public GameObject Slice;
    public GameSettings Settings;
    public Progress Progress;

}
