using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour
{
    public double CurrentLatitude;
    public double CurrentLongitude;
    public double CurrentAltitude;
    public double HorizontalAccuracy;
    public double TimeStamp;

    [SerializeField] private float _timer = 30f;
    private float _currentTimer;

    public bool HasLocation = false;


    public void Start()
    {
        _currentTimer = _timer;
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
            _currentTimer = _timer;
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            HasLocation = false;
            yield break;
        }

        //Access granted
        HasLocation = true;
        _currentTimer = _timer;
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
