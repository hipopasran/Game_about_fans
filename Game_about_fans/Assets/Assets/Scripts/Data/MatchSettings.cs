using UnityEngine;

[CreateAssetMenu(fileName = "MatchSettings", menuName = "Data/MatchSettings")]
public class MatchSettings : ScriptableObject {

    public Character Character;
    public GameSettings Settings;
    public Progress Progress;
    public Character[] ShopCharaters;

}
