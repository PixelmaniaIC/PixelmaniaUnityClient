﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Messages;
using UnityEngine;

public class TcpUnityClient : MonoBehaviour
{
    public static TcpUnityClient instance = null;

    // host address and port
    public string host = "52.237.74.136";
    public int port = 4040;

    private ReceiveManager _receiveManager;
   
    #region NetworkEntities
    
    private TcpClient _tcpSocket;
    private NetworkStream _netStream;
    private StreamWriter _socketWriter;
    private StreamReader _socketReader;
    
    #endregion
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        _receiveManager = new ReceiveManager(GetComponents<IReceivable>());
        DontDestroyOnLoad(gameObject);
        SetupSocket();
    }

    private void Update()
    {
        string received_data = ReadSocket();

        if (received_data != null)
        {
            Debug.Log(received_data);
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
            Debug.Log("Start connection");
            _tcpSocket = new TcpClient(host, port);
            _netStream = _tcpSocket.GetStream();
            _socketWriter = new StreamWriter(_netStream);
            _socketReader = new StreamReader(_netStream);
            Debug.Log("Connected to localhost");

        }
        catch (Exception e)
        {
            Debug.LogError("Socket error: " + e);
        }
    }

    public void SendServerMessage(Message sendMessage)
    {
        var jsonMessage = JsonUtility.ToJson(sendMessage);
        Debug.Log(jsonMessage);
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
        // TODO: Должен придумать PlayerId
        if (_netStream.DataAvailable)
            return _socketReader.ReadLine();

        return null;
    }

    private void CloseSocket()
    {
        _socketWriter.Close();
        _socketReader.Close();
        _tcpSocket.Close();
    }

}