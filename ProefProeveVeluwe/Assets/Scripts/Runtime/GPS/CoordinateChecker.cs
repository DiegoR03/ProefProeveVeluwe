using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Checks the distance between the player coordinates and the waypoint coordinates.
/// </summary>
public class CoordinateChecker : MonoBehaviour
{   
    [Header("Waypoint Data")]
    [Tooltip("Waypoint Radius is in Kilometers")][SerializeField] private float WaypointRadius;
    [SerializeField] private GPSWayPointsData[] WayPoints;

    [SerializeField] private GPS GPSData;
    private double[] _distances;

    [Space]
    [Header("Debug")]
    [SerializeField] private Text[] DebugText; //a bit hardcoded for debugging
    [SerializeField] private GameObject MinigameButton;
    [SerializeField] private Text ButtonText;

    private void Start()
    {
        _distances = new double[WayPoints.Length];
    }

    private void Update()
    {
        var CurLon = GPSData.CurrentLongitude;
        var CurLat = GPSData.CurrentLatitude;

        //cycles trough the waypoint objects and calculates the distance for each
        for (int i = 0; i < WayPoints.Length; i++)
        {
            _distances[i] = Distance(CurLat, CurLon, WayPoints[i].LatitudeValue, WayPoints[i].LongitudeValue);
        }

        //checks if you are close to one of the waypoints.
        for (int i = 0; i < _distances.Length; i++)
        {
            if (_distances[i] < WaypointRadius)
            {
                MinigameButton.SetActive(true);
                DebugText[i].text = _distances[i].ToString();
                ButtonText.text = "Je bent dichtbij punt " + WayPoints[i].name;
                return;
            }
            MinigameButton.SetActive(false);
            DebugText[i].text = _distances[i].ToString();
        }
    }

    /// <summary>
    ///    Function uses a double because casting to float is a bit innefficient
    ///    The haversine formula determines the great-circle distance between two points on a sphere given their longitudes and latitudes. 
    ///    Important in navigation, it is a special case of a more general formula in spherical trigonometry, the law of haversines, that relates the sides and angles of spherical triangles.
    ///    Reference for the formula https://en.wikipedia.org/wiki/Haversine_formula
    /// </summary>
    /// <returns></returns>
    
    private double ToRadians(double degrees)
    {
        //degrees converted to radians
        return degrees * Mathf.PI / 180;
    }
    
    public double Distance(double lat1, double lon1, double lat2, double lon2)
    {
        const double radius = 6371.0 ; // Earth's radius in Kilometers specific

        var dLat = ToRadians(lat2 - lat1);
        var dLon = ToRadians(lon2 - lon1);

        var a = Mathf.Sin((float) (dLat / 2)) * Mathf.Sin((float) (dLat / 2)) +
                Mathf.Cos((float) ToRadians(lat1)) * Mathf.Cos((float) ToRadians(lat2)) *
                Mathf.Sin((float) (dLon / 2)) * Mathf.Sin((float) (dLon / 2));

        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        var distance = radius * c;

        return distance; //distance in Kilometer
    }
}
