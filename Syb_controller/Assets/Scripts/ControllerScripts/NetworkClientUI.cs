using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net;
using System.Net.Sockets;

public class NetworkClientUI : NetworkManager
{
    void OnGUI()
    {
        string ipAddress = LocalIPAddress();
        GUI.Box(new Rect(10, Screen.height - 50, 100, 50), ipAddress);
        GUI.Label(new Rect(20, Screen.height - 30, 100, 20), "Status: " + NetworkClient.isConnected);
        
        if(!NetworkClient.isConnected)
        {
            if(GUI.Button(new Rect(10,10,60,50), "Connect"))
            {
                NetworkClient.Connect("192.168.1.6");
            }
        }
    }

    public string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
