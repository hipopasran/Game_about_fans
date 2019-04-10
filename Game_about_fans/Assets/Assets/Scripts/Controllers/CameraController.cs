using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /* 
     * This is script for camera for "Game" scene.
     * Follow to player and other things you need write here.
     */

    public Transform Player;

    [SerializeField]
    private float smooth = 2.5f;
    [SerializeField]
    private float offset;
    [SerializeField]
    private SpriteRenderer boundsMap;

    private Vector3 minBound;
    private Vector3 maxBound;
    private Vector3 direction;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
        CalculateBounds();
        cam.transform.position = new Vector3(Player.position.x, Player.position.y, cam.transform.position.z);

        Follow();
    }

    private void CalculateBounds()
    {
        if(boundsMap == null)
        {
            return;
        }

        Bounds bounds = Camera2DBounds();
        minBound = bounds.max + boundsMap.bounds.min;
        maxBound = bounds.min + boundsMap.bounds.max;
    }

    private Bounds Camera2DBounds()
    {
        float height = cam.orthographicSize * 2;
        return new Bounds(Vector3.zero, new Vector3(height * cam.aspect, height, 0));
    } 

    private Vector3 MoveInside(Vector3 current, Vector3 pMin, Vector3 pMax)
    {
        if(boundsMap == null)
        {
            return current;
        }

        current = Vector3.Max(current, pMin);
        current = Vector3.Min(current, pMax);
        return current;
    }

    private void Follow()
    {
        direction = Player.right;
        Vector3 position = Player.position + direction * offset;
        position = MoveInside(position, new Vector3(minBound.x, minBound.y, transform.position.z), new Vector3(maxBound.x, maxBound.y, transform.position.z));
        transform.position = Vector3.Lerp(transform.position, position, smooth * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if(Player)
        {
            Follow();
        }
    }
}
