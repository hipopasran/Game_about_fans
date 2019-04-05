using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridLocator : MonoBehaviour {

    [SerializeField]
    private Vector2 gridSize;
    [SerializeField]
    private int columnAmount;



	/*void OnValidate()
    {
        List<AnimationSprites> dudes = GetComponent<DudeControlUnit>().dudes;

        int column = 0;
        int row = 0;

        Vector2 startPos = Camera.main.ScreenToWorldPoint(Vector2.zero);

        print(dudes.Count);
        foreach(var dude in dudes)
        {
            dude.transform.position = new Vector2(column * gridSize.x, row * gridSize.y) + startPos;
            column++;

            if(column >= columnAmount)
            {
                row++;
                column = 0;
            }
            print(column * gridSize.x + " " + row * gridSize.y + " " + 0f);
        }
    }*/
}
