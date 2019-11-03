using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class OutputManager : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _deviceGyro;
    public Vector3 GyroRotation;

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
        if(_gyroEnabled)
        {
            GyroRotation = _deviceGyro.attitude.eulerAngles;
            //Debug.Log(GyroRotation);
            NetworkClientUI.SendGyroOrientation(GyroRotation);
        }
    }

    public Vector3 GetGyro()
    {
        return GyroRotation;
    }
}
