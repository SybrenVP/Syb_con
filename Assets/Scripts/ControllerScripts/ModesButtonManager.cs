using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModesButtonManager : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private GameObject _joystickMode;
    [SerializeField] private GameObject _controllerMode;
    [SerializeField] private GameObject _steeringWheelMode;
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
        SetButtonColors();
    }

    private void SetButtonColors()
    {
        //Joystick button
        if (_supportJoystick)
        {
            _buttons[0].image.color = Color.green;
        }
        else
        {
            _buttons[0].image.color = Color.red;
            _buttons[0].interactable = false;
        }

        //controller button
        if (_supportController)
        {
            _buttons[1].image.color = Color.green;
        }
        else
        {
            _buttons[1].image.color = Color.red;
            _buttons[1].interactable = false;
        }

        //Steering wheel button
        if (_supportWheel)
        {
            _buttons[2].image.color = Color.green;
        }
        else
        {
            _buttons[2].image.color = Color.red;
            _buttons[2].interactable = false;
        }
    }
}
