using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Checks the distance between the player and waypoint
/// </summary>
public class WaypointDistanceCheck : MonoBehaviour
{
    [SerializeField] private float wayPointRadius = 2;
    [SerializeField] private Text wayPointText;
    private GPSWayPointsData gpsWayPointsData;
    private float _currentLongitude;
    private float _currentLatitude;

    void Start()
    {
        wayPointText = GetComponent<Text>();
    }

    void Update()
    {
        CheckValue();
        CheckPlayerDistance();
    }

    /// <summary>
    /// Retrieves the current location of the player
    /// </summary>
    void CheckValue()
    {
        _currentLongitude = Input.location.lastData.longitude;
        _currentLatitude = Input.location.lastData.latitude;
    }

    /// <summary>
    /// Checks if the player is within the radius of the waypoint
    /// </summary>
    void CheckPlayerDistance()
    {
        Vector2 point = new Vector3(wayPointRadius, 0, 0);
        Vector2 waypointData = new Vector2(gpsWayPointsData.LatitudeValue, gpsWayPointsData.LongitudeValue);
        point = Quaternion.Euler(0, _currentLatitude, _currentLongitude) * point;

        if (waypointData == point)
        {
            wayPointText.text = "You have arrived at the waypoint";
        }
    }

}
