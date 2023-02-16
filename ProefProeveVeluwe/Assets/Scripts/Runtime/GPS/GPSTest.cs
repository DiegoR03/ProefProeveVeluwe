using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPSTest : MonoBehaviour
{
    [SerializeField] private Text GPSStatus;
    [SerializeField] private Text latitudeValue;
    [SerializeField] private Text longitudeValue;
    [SerializeField] private Text altitudeValue;
    [SerializeField] private Text horizontalAccuracyValue;
    [SerializeField] private Text timeStampValue;

    private void Start() { StartCoroutine(GPSLocation()); }

    IEnumerator GPSLocation()
    {
        //check if location is enabled
        if (!Input.location.isEnabledByUser) yield break;
        Input.location.Start();

        //wait until service initialize
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // service didn't init in 20 sec
        if (maxWait < 1)
        {
            GPSStatus.text = "Time Out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            //Access granted
            GPSStatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1);
        }
    }
    
    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            //acces granted to GPS values and it has been initialized
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timeStampValue.text = Input.location.lastData.timestamp.ToString();
        }
        else
        {
            //service has been stopped
            GPSStatus.text = "Stop";
        }
    }
}
