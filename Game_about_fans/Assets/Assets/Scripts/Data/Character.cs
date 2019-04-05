using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Data/Charater")]
public class Character : ScriptableObject {

    public new string Name;
    public int Cost;
    public Sprite Sprite;
    public bool Avaliablity;

}
