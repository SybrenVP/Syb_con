using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class JoystickMode_output : MonoBehaviour
{
    private bool _gyroEnabled;
    private Gyroscope _deviceGyro;
    private Vector3 _gyroRotation;
    private StringMessage _gyroMessage = new StringMessage();

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

    void Update()
    {
        if(_gyroEnabled)
        {
            Quaternion rot = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * _deviceGyro.attitude * new Quaternion(0,0,1,0);
            _gyroRotation = rot.eulerAngles;

            _gyroMessage.value = _gyroRotation.ToString();
            NetworkClientUI.SendToServer(_gyroMessage, (short)MessageTypes.orientation);
        }
    }

    public Vector3 GetGyro()
    {
        return _gyroRotation;
    }
}
