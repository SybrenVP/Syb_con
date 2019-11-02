using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControllerNetworking : Mirror.NetworkBehaviour
{
    public OutputManager OutputMan;

    [Mirror.SyncVar]
    public Vector3 ControllerRot;
    
    public override void OnStartServer()
    {
        base.OnStartServer();
        InvokeRepeating(nameof(UpdateData), 1, 1);
    }

    [Mirror.ServerCallback]
    void UpdateData()
    {
        //Update controller variables
        ControllerRot = OutputMan.GetGyro();
    }
}
