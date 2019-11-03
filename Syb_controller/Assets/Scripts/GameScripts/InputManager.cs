using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static private Vector3 _orientation;
    static private Vector3 _calibratedOrientation = new Vector3(0,0,0);

    void Update()
    {
        _orientation = NetworkServerUI.GetClientGyro();
        
        Debug.Log(_orientation);
        transform.rotation = Quaternion.Euler(_orientation - _calibratedOrientation);
    }

    public static void Calibrate()
    {
        _calibratedOrientation = _orientation;
    }
}
