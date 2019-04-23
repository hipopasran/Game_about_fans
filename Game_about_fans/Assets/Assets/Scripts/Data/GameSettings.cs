using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Data/GameSettings")]
public class GameSettings : ScriptableObject {

    /* 
     * Data about main game settings. 
     * Now it is only about music & sounds.
     * Also need add other game settings like promotions.
     * 
     * Standart Charecter Skin - dudeBlueShirt
     * Standart Enemy Skin - dudeGreenCap  
     */ 

    public bool Music;
    public bool Effect;

}
