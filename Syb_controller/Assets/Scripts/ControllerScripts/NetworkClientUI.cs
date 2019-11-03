using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class NetworkClientUI : NetworkManager
{
#pragma warning disable 649
    [SerializeField] private Button _connectButton;
    [SerializeField] private Text _ip;
    [SerializeField] private Text _status;
    [SerializeField] private Text _serverIPAddress;
#pragma warning restore 649


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
    
    static public void SendGyroOrientation(Vector3 gyro)
    {
        if(NetworkClient.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = gyro.ToString();
            NetworkClient.Send(888, msg);
        }
    }

    private void Start()
    {
        _ip.text = "Device IP: " + LocalIPAddress();
    }

    private void Update()
    {
        if(NetworkClient.isConnected)
        {
            _status.text = "Status: Connected";
            _connectButton.gameObject.SetActive(false);
        }
        else
        {
            _status.text = "Status: Not connected";
            _connectButton.gameObject.SetActive(true);
        }
    }

    public void Connect()
    {
        NetworkClient.Connect(_serverIPAddress.text);
    }

    public void Calibrate()
    {
        if(NetworkClient.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = true.ToString();
            NetworkClient.Send(887, msg);
        }
    }
}
