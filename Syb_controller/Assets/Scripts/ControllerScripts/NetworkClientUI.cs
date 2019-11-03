using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public enum MessageTypes
{
    calibrate = 0,
    orientation = 1
}

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

    public void Calibrate()
    {
        StringMessage msg = new StringMessage();
        msg.value = "";
        SendToServer(msg, (short)(MessageTypes.calibrate));
    }

    static public void SendToServer(StringMessage msg, short msgType)
    {
        if(NetworkClient.isConnected)
        {
            NetworkClient.Send(msgType, msg);
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
}
