using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orientation = NetworkServerUI.GetClientGyro();
        transform.rotation = Quaternion.Euler(orientation);
    }
}
