using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ModesButtonManager : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private List<Button> _buttons;
#pragma warning restore 649
    private bool _modesReceived;
    private bool _supportJoystick;
    private bool _supportController;
    private bool _supportWheel;

    //1. This script becomes active
    //2. Gets the game information from the server
    //3. Changes the color of the buttons to red if inactive / green if active
    //4. When a button has been pressed disable this layer in the MenuManager. 

    public void SetSupportedModes(bool joystick, bool controller, bool wheel)
    {
        _supportJoystick = joystick;
        _supportController = controller;
        _supportWheel = wheel;
        _modesReceived = true;
    }

    private void Update()
    {
        if(_modesReceived)
        {

        }
    }
}
