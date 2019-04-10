using UnityEngine;

[CreateAssetMenu(fileName = "Progress", menuName = "Data/Progress")]
public class Progress : ScriptableObject {

    /* 
     * Data about progress.
     */

    public int Cash;
    public int LastScore;
    public int BestScore;
	
}
