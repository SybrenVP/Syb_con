using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static private Vector3 orientation;
    static private Vector3 standardOrientation = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orientation = NetworkServerUI.GetClientGyro();
        
        Debug.Log(orientation);
        transform.rotation = Quaternion.Euler(orientation - standardOrientation);
    }

    public static void Calibrate()
    {
        standardOrientation = orientation;
    }
}
