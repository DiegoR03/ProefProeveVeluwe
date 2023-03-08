using UnityEngine;
using UnityEngine.UI;

public class CoordinateChecker : MonoBehaviour
{
    [Tooltip("Longitude is East to West")][SerializeField] private double WaypointLongitude;
    [Tooltip("Latitude is North to South")][SerializeField] private double WaypointLatitude;
    
    [SerializeField] private GPS GPSData;
    [Tooltip("Waypoint Radius is in Kilometers")][SerializeField] private float WaypointRadius;
    
    //debug
    [SerializeField] private Text TCurrentDistance;
    [SerializeField] private GameObject MinigameButton;

    private void Update()
    {
        var CurLon = GPSData.CurrentLongitude;
        var CurLat = GPSData.CurrentLatitude;
        
        var CurrentDistance = Distance(CurLat, CurLon, WaypointLatitude, WaypointLongitude);

        TCurrentDistance.text = CurrentDistance.ToString();
        
        if (CurrentDistance < WaypointRadius)
        {
            MinigameButton.SetActive(true);
            return;
        }
        MinigameButton.SetActive(false);
    }

    /*
        Function uses a double because casting to float is a bit innefficient
        The haversine formula determines the great-circle distance between two points on a sphere given their longitudes and latitudes. 
        Important in navigation, it is a special case of a more general formula in spherical trigonometry, the law of haversines, that relates the sides and angles of spherical triangles.
        //Reference for the formula https://en.wikipedia.org/wiki/Haversine_formula
    */

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

        return distance; //distance in Meters
    }
}
