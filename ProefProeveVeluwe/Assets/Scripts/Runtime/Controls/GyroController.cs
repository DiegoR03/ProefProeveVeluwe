using UnityEngine;

public class GyroController : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _gyroscope;

    [SerializeField] private GameObject _cameraContainer;
    private Quaternion _rotation;

    private void Start()
    {
        _cameraContainer.transform.position = transform.position;
        transform.SetParent(_cameraContainer.transform);
        
        _gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            _gyroscope = Input.gyro;
            _gyroscope.enabled = true;
            
            _cameraContainer.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            _rotation = new Quaternion(0, 0,1, 0);
            
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (!_gyroEnabled) return;

        //Quaternion.Lerp(transform.localRotation * _rotation, _gyroscope.attitude * _rotation, 1);
        transform.localRotation = _gyroscope.attitude * _rotation;
    }
}
