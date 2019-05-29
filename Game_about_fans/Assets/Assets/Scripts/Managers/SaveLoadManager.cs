using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveLoadManager : MonoBehaviour {

    public TextMeshProUGUI CoinText;
    public Progress Progress;
    /*
     * Data logic. Save & Load.
     */

    // Use this for initialization
    void Awake ()
    {
        CoinText.text = Progress.Cash.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
