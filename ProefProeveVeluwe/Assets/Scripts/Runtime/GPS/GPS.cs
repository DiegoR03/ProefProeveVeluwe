using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    /// <summary>
    /// Gets the current GPS values of the Device.
    /// </summary>
    public class GPS : MonoBehaviour
    {
        [SerializeField] private Text GPSStatus;
        [SerializeField] private Text latitudeValue;
        [SerializeField] private Text longitudeValue;
        [SerializeField] private Text altitudeValue;
        [SerializeField] private Text horizontalAccuracyValue;
        [SerializeField] private Text timeStampValue;
        [SerializeField] private Text updateRateValue;
        
        private int _currentTimer;
        private int _maxTimer = 20;

        private int _updateValue;

        private void Start()
        {
            _currentTimer = _maxTimer;
            StartCoroutine(GPSLocation());
        }
        
        /// <summary>
        /// When the player clicks on the retry button the coroutine will restart
        /// </summary>
        private void OnRetryClick()
        {
            _currentTimer = _maxTimer;
            GPSStatus.text = "...";
            StartCoroutine(GPSLocation());
        }

        /// <summary>
        /// checks the device for location data
        /// </summary>
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
                GPSStatus.text = "Time Out";
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                GPSStatus.text = "Unable to determine device location";
                yield break;
            }

            //Access granted
            _updateValue++;
            InvokeRepeating("UpdateGPSData", 0.5f, 1);
        }

        /// <summary>
        /// Fills in text with the GPS Data 
        /// </summary>
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
                updateRateValue.text = _updateValue.ToString();

                return;
            }

            //service has been stopped
            GPSStatus.text = "Stop";
        }
    }
}
