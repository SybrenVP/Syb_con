using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputManager : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _deviceGyro;

    private void Start()
    {
        _gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            _deviceGyro = Input.gyro;
            _deviceGyro.enabled = true;
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(SystemInfo.supportsGyroscope)
        {
            Quaternion deviceRot = _deviceGyro.attitude;
            Debug.Log(deviceRot.eulerAngles);
        }

        
    }
}
