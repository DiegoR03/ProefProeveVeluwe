using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapForumThing : MonoBehaviour
{
    public float latitude;
    public float longitude;

    public Image equirectMap;
    public GameObject marker;

    public float mapWidth;
    public float mapHeight;


    private void Start()
    {
        mapWidth = equirectMap.minWidth;
        mapHeight = equirectMap.minHeight;

        marker.transform.position = equirectVector2();
    }

    public Vector2 equirectVector2()
    {
        float x = (longitude + 180) * (mapWidth / 360);
        float y = (latitude + 90) * (mapHeight / 180);
        Vector2 markerPosition = new Vector2(x, y);
        return markerPosition;
    }
}