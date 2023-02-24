using System;
using UnityEngine;

/// <summary>
/// This scriptable object is used to create waypoints for the system to store and use in a list.
/// </summary>
[CreateAssetMenu(fileName = "GPSWayPointsData", menuName = "GPSWayPointsData", order = 1)]
public class GPSWayPointsData : ScriptableObject
{
    [SerializeField, Tooltip("Retrieves the name of the waypoint")] private string waypointName;
    [SerializeField, Tooltip("Gets the latitude value of the location within the GPS")] private Double latitudeValue;
    [SerializeField, Tooltip("Get the longitude value of the location within the GPS")] private Double longitudeValue;

    //The data for the waypoints
    public string WaypointName => waypointName;
    public Double LatitudeValue => latitudeValue;
    public Double LongitudeValue => longitudeValue;
}
