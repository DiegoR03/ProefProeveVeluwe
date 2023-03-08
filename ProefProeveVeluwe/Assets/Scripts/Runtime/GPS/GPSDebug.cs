using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    /// <summary>
    /// Gets the current GPS values of the Device.
    /// </summary>
    public class GPSDebug : MonoBehaviour
    {
        [SerializeField] private Text GPSStatus;
        [SerializeField] private Text latitudeValue;
        [SerializeField] private Text longitudeValue;
        [SerializeField] private Text altitudeValue;
        [SerializeField] private Text horizontalAccuracyValue;
        [SerializeField] private Text timeStampValue;

        private GPS _GPSData;

        private float _maxTimer = 3f;
        private float _currentTimer;
        

        private void Start()
        {
            _GPSData = FindObjectOfType<GPS>();
        }
        

        /// <summary>
        /// checks the device for location data
        /// </summary>
        private void Update()
        {
            if (_GPSData.HasLocation == false)
            {
                GPSStatus.text = "Failed To Connect";
                _currentTimer = 0f;
                return;
            }

            if (_currentTimer>_maxTimer)
            {
                UpdateDebugWindow();
                Debug.Log(_currentTimer);
                _currentTimer = 0f;
            }

            _currentTimer += Time.deltaTime;
        }

        /// <summary>
        /// Fills in text with the GPS Data 
        /// </summary>
        private void UpdateDebugWindow()
        {
            //acces granted to GPS values and it has been initialized
            GPSStatus.text = "Running";

            latitudeValue.text = _GPSData.CurrentLatitude.ToString();
            longitudeValue.text = _GPSData.CurrentLongitude.ToString(); altitudeValue.text = _GPSData.CurrentAltitude.ToString();
            horizontalAccuracyValue.text = _GPSData.HorizontalAccuracy.ToString();
            timeStampValue.text = _GPSData.TimeStamp.ToString();
                
        }
    }
}
