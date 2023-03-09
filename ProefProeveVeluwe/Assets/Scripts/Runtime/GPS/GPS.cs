using UnityEngine;
using System.Collections;

/// <summary>
/// Checks if location data is allowed to be used by the owner of the device
/// gets all GPS location data from device and stores that info in the variables
/// </summary>
public class GPS : MonoBehaviour
{
    [Header("Data")]
    public double CurrentLatitude;
    public double CurrentLongitude;
    public double CurrentAltitude;
    public double HorizontalAccuracy;
    public double TimeStamp;

    [Header("Approve Location")]
    [SerializeField] private float Timer = 30f;
    private float _currentTimer;

    public bool HasLocation;
    
    
    public void Awake()
    {
        _currentTimer = Timer;
        StartCoroutine(GPSLocation());
    }
    
    private IEnumerator GPSLocation()
    {
        //check if location is enabled
        if (!Input.location.isEnabledByUser) yield break;
        Input.location.Start();

        //wait until service initialize
        while (Input.location.status == LocationServiceStatus.Initializing && _currentTimer > 0)
        {
            yield return new WaitForSeconds(1);
            _currentTimer--;
        }

        // service didn't init in maxTimer sec
        if (_currentTimer < 1)
        {
            HasLocation = false;
            _currentTimer = Timer;
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            HasLocation = false;
            yield break;
        }

        //Access granted
        HasLocation = true;
        _currentTimer = Timer;
        InvokeRepeating("UpdateGPSData", 0.5f, 1);
    }
    
    private void UpdateGPSData()
    {
        CurrentLatitude = Input.location.lastData.latitude;
        CurrentLongitude = Input.location.lastData.longitude;
        CurrentAltitude = Input.location.lastData.altitude;
        HorizontalAccuracy = Input.location.lastData.horizontalAccuracy;
        TimeStamp = Input.location.lastData.timestamp;
    }
}
