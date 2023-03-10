
using UnityEngine;


public class GPSConverter : MonoBehaviour
{
    //MapLatitude and Longitude is the Lat,Long Values of the centerpoint of the map; you get this to calculate the distance between
    public static Vector2 ConvertGPSToXY(double latitude, double longitude, double mapLatitude, double mapLongitude, double mapWidth, double mapHeight)
    {
        // Calculate the distance between the user and the map center
        double dx = (longitude - mapLongitude) * Mathf.Deg2Rad * 6371000 * Mathf.Cos((float)latitude * Mathf.Deg2Rad);
        double dy = (latitude - mapLatitude) * Mathf.Deg2Rad * 6371000;

        // Calculate the x and y position of the user on the map
        float x = (float)(((dx / mapWidth) + 0.5) * mapWidth);
        float y = (float)(((dy / mapHeight) + 0.5) * mapHeight);

        return new Vector2(x, y);
    }

}