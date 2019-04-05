using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DudeControlUnit : MonoBehaviour {

    public List<AnimationSprites> dudes;

	public void WalkAll()
    {
        foreach(var dude in dudes)
        {
            dude.ToggleWalk();
        }
    }

    public void BoredAll()
    {
        foreach (var dude in dudes)
        {
            dude.Bored();
        }
    }
}
