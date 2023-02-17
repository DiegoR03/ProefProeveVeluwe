using UnityEngine;

/// <summary>
/// This scriptable object is used to create waypoints for the system to store and use in a list.
/// </summary>
[CreateAssetMenu(fileName = "GPSWayPointsData", menuName = "GPSWayPointsData", order = 1)]
public class GPSWayPointsData : ScriptableObject
{
    [SerializeField, Tooltip("Retrieves the name of the waypoint")] private string waypointName;
    [SerializeField, Tooltip("Gets the latitude value of the location within the GPS")] private float latitudeValue;
    [SerializeField, Tooltip("Get the longitude value of the location within the GPS")] private float longitudeValue;

    //The data for the waypoints
    public string WaypointName => waypointName;
    public float LatitudeValue => latitudeValue;
    public float LongitudeValue => longitudeValue;
}
