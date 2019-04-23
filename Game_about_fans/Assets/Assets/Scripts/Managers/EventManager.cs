using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    /*
     *  Event manager for gameplay. It is for working with collision and other event during match.
     */

    public delegate void HitAction(GameObject first, GameObject second);
    public static event HitAction Hited;

    // Colision between enemies, player and other stuff.
    public void OnHited(GameObject first, GameObject second)
    {
        Hited(first, second);
    }
}
