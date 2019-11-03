using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControllerMode
{
    None = 0,
    Standard = 1,
    Joystick = 2,
    SteeringWheel = 3
}


public class ControllerManager : MonoBehaviour
{
    private ControllerMode _mode = ControllerMode.None;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
