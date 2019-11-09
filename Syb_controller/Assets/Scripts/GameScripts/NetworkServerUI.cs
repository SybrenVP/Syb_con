using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net;
using System.Net.Sockets;
using System;

public class NetworkServerUI : NetworkManager
{
    #region joystickVars
    private static Vector3 ClientGyro;
    #endregion

    #region controllerVars
    #endregion

    #region wheelVars
    #endregion

    #region overallGames
    [Header("Game variables")]
    public bool supportJoystick = true;
    public bool supportController = false;
    public bool supportWheel = false;
    #endregion

    private void OnGUI()
    {
        string ipAddress = LocalIPAddress();
        GUI.Box(new Rect(10, Screen.height - 50, 100, 50), ipAddress);
        GUI.Label(new Rect(20, Screen.height - 35, 100, 20), "Status: " + NetworkServer.active);
        GUI.Label(new Rect(20, Screen.height - 20, 100, 20), "Connected: " + NetworkServer.connections.Count);
    }

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach(IPAddress ip in host.AddressList)
        {
            if(ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
    void Start()
    {
        NetworkServer.Listen(2500);
        NetworkServer.RegisterHandler(888, ServerReceiveGyro);
        NetworkServer.RegisterHandler(887, Calibrate);
        NetworkServer.RegisterHandler(886, SendAvailableModes);
    }

    private void ServerReceiveGyro(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;

        ClientGyro = StringToVector3(msg.value);
    }

    private void Calibrate(NetworkMessage message)
    {
        InputManager.Calibrate();
    }

    
    private void SendAvailableModes(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = supportJoystick.ToString() + ',' + supportController.ToString() + ',' + supportWheel.ToString().ToString();

        NetworkServer.SendToAll(777, msg);
    }

    public Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }

    public static Vector3 GetClientGyro()
    {
        return ClientGyro;
    }
}
