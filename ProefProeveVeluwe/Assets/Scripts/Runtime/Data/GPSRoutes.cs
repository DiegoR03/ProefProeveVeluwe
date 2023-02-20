using UnityEngine;

/// <summary>
/// This script uses the waypoint data en puts together the route in an array.
/// </summary>
[CreateAssetMenu(fileName = "GPSRoutes", menuName = "GPSRoute", order = 1)]
public class GPSRoutes : ScriptableObject
{
    [SerializeField] private GPSWayPointsData[] wayPoints;

    //retrieves all the waypoint put in a List
    public GPSWayPointsData[] GetAllWayPoints()
    {
        return wayPoints;
    }
}
