using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Messages;
using UnityEngine;

public class TcpUnityClient : FinishGameListener
{
    public static TcpUnityClient instance = null;

    // host address and port
    public string host = "";
    public int port = 0000;

    private ReceiveManager _receiveManager;
    private Boolean _connectionOpened = false;

    #region NetworkEntities
    
    private TcpClient _tcpSocket;
    private NetworkStream _netStream;
    private StreamWriter _socketWriter;
    private StreamReader _socketReader;

    #endregion

    public override void OnGameFinished()
    {
        CloseSocket();
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        _receiveManager = new ReceiveManager(GetComponents<IReceivable>());
        SetupSocket();
    }

    private void Update()
    {
        if (!_connectionOpened) return;

        string received_data = ReadSocket();

        if (received_data != null)
        {
            _receiveManager.Process(received_data);
        }
    }

    private void OnApplicationQuit()
    {
        CloseSocket();
    }

    private void SetupSocket()
    {
        try
        {
            _tcpSocket = new TcpClient(host, port);
            _netStream = _tcpSocket.GetStream();
            _socketWriter = new StreamWriter(_netStream);
            _socketReader = new StreamReader(_netStream);

            _connectionOpened = true;
        }
        catch (Exception e)
        {
            Debug.LogError("Socket error: " + e);
        }
    }

    public void SendServerMessage(Message sendMessage)
    {
        if (!_connectionOpened) return;

        var jsonMessage = JsonUtility.ToJson(sendMessage);
        WriteSocket(jsonMessage);
    }

    private void WriteSocket(string line)
    {
        line = line + "\r\n";
        _socketWriter.Write(line);
        _socketWriter.Flush();
    }

    private String ReadSocket()
    {
        if (_netStream.DataAvailable)
            return _socketReader.ReadLine();

        return null;
    }

    public void CloseSocket()
    {
        _socketWriter.Close();
        _socketReader.Close();
        _tcpSocket.Close();

        _connectionOpened = false;
    }
}