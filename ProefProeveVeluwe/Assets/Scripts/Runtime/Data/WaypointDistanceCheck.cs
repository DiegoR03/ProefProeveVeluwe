using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Checks the distance between the player and waypoint
/// </summary>
public class WaypointDistanceCheck : MonoBehaviour
{
    [SerializeField] private float wayPointRadius = 200;
    [SerializeField] private GameObject MinigameButton;
    [SerializeField] private GPSWayPointsData[] gpsWayPointsData;
    private float _currentLongitude;
    private float _currentLatitude;

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
        Vector3 point = new Vector3(_currentLatitude, 0, _currentLongitude);
        Vector3 waypointData = new Vector3(gpsWayPointsData[0].LatitudeValue, 0, gpsWayPointsData[0].LongitudeValue);
        point = Quaternion.Euler(_currentLatitude, 0, _currentLongitude) * point;

        if (Vector3.Distance(waypointData, point) < wayPointRadius)
        {
            MinigameButton.SetActive(true);
        }
        MinigameButton.SetActive(false);
    }

}
