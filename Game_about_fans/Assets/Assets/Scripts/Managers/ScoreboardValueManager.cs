using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreboardValueManager : MonoBehaviour {

    public TextMeshProUGUI LastScoreText;
    public TextMeshProUGUI BestScoreText;

    [Header("Data")]
    public Progress Progress;

    // Use this for initialization
    void Awake ()
    {
        LastScoreText.text = Progress.LastScore.ToString();
        BestScoreText.text = Progress.BestScore.ToString();
    }
	
}
