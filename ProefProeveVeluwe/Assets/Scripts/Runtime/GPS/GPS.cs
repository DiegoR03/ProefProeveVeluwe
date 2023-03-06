using System.Collections;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public double CurrentLatitude;
    public double CurrentLongitude;
    public double CurrentAltitude;
    public double HorizontalAccuracy;
    public double TimeStamp;

    [SerializeField] private float _timer = 30f;
    private float _currentTimer;
    
    private int _updateRate = 10; //in Seconds

    private void Start()
    {
        _currentTimer = _timer;
    }

    private void Update()
    {
        if (_currentTimer ! >= _timer)
        {
            _currentTimer += Time.deltaTime;
            return;
        }
       
        _currentTimer = 0f;
        StartCoroutine(LocationChecker());
    }

    IEnumerator LocationChecker()
    {
        //check if location is enabled
        if (!Input.location.isEnabledByUser) yield break;
        
        Input.location.Start();

        //wait until service initialize
        while (Input.location.status == LocationServiceStatus.Initializing && _updateRate > 0)
        {
            yield return new WaitForSeconds(1);
            _updateRate--;
        }

        // service didn't init in maxTimer sec
        if (_updateRate < 1) { yield break; }

        //failed to Get service
        if (Input.location.status == LocationServiceStatus.Failed) { yield break; }

        //Access granted
        UpdateGPSData();
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
