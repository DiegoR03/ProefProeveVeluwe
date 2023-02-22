using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    private Gyroscope _Gyro;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        _Gyro = Input.gyro;
        _Gyro.enabled = true;
    }

//This is a legacy function, check out the UI section for other ways to create your UI
    void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + _Gyro.rotationRate);
        GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + _Gyro.attitude);
        GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + _Gyro.enabled);
    }
}
