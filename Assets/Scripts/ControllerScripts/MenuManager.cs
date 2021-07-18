using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuLayers
{
    None = 0,
    Connect = 1,
    Modes = 2,
    JoystickMode = 3,
    ControllerMode = 4,
    SteeringWheelMode = 5
}


public class MenuManager : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private List<GameObject> _layers;
#pragma warning restore 649

    private MenuLayers _activeLayer;
    // Start is called before the first frame update
    void Start()
    {
        _activeLayer = MenuLayers.Connect;
    }

    public void SetActiveLayer(MenuLayers layer)
    {
        _layers[(int)_activeLayer].SetActive(false);
        _activeLayer = layer;
        _layers[(int)_activeLayer].SetActive(true);
    }

    //button code
    public void JoystickMode()
    {
        SetActiveLayer(MenuLayers.JoystickMode);
    }

    public void ControllerMode()
    {
        SetActiveLayer(MenuLayers.ControllerMode);
    }

    public void SteeringWheelMode()
    {
        SetActiveLayer(MenuLayers.SteeringWheelMode);
    }
}
