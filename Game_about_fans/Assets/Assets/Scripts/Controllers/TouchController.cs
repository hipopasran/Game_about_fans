using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    /*
     *  Virtual stick for player movement on Game scene. 
     */

    public Vector2 Direction;

    private Vector2 startPosition;          // position of first touching
    private Vector2 currentPosition;        // position of current touching
    private Vector2 lastDirection;          // last direction of player walk
    private float stickDeadZone = 100;      // dead zone for virtual stick
    private bool isMouseTouching;           // still click or not
    


	// Reset after wake up
	void Awake ()
    {
        Reset();
        Direction = lastDirection = Vector2.right;
	}
	

    // Function fot reset value after end of using stick
    private void Reset()
    {
        startPosition = currentPosition = Vector2.zero;
        isMouseTouching = false;

        // Debug mode
        Debug.Log("Новое");
    }


    // Function for catching touches and theirs status
    public void TouchControll()
    {

        #region MouseInput

        if(Input.GetMouseButtonDown(0))
        {
            isMouseTouching = true;
            startPosition = Input.mousePosition;
        }

        // If finished press of button
        if(Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        // Check if putton still pressing
        if(isMouseTouching)
        {
            currentPosition = ((Vector2)Input.mousePosition - startPosition).normalized;
            StickLogic();
        }

        #endregion

        #region MobileInput

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                startPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                currentPosition = (touch.position - startPosition).normalized;
                StickLogic();
            }
            else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                Reset();
            }
            else
            {
                Reset();
            }
        }

        #endregion
    }

    // Calculate direction for player
    private void StickLogic()
    {
        //angle between last and current direction
        //float angle = 0;

        if(currentPosition != Vector2.zero)
        {
            //angle = Vector2.SignedAngle(lastDirection, currentPosition);

            //Direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
            Direction = currentPosition;
            lastDirection = lastDirection - Direction;
            
        }
    }
}
