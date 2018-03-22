using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messages;
using UnityEngine;

[Serializable]
public class SendMessage : IReceivable
{
    public string playerId;
    public float r;
    public float g;
    public float b;

    public string NetworkName
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public SendMessage() { }

    public SendMessage(string playerId, float r, float g, float b)
    {
        this.playerId = playerId;
        this.r = r;
        this.b = b;
        this.g = g;
    }

    public SendMessage(string playerId, Color color)
    {
        this.playerId = playerId;
        this.r = color.r;
        this.g = color.g;
        this.b = color.b;
    }

    public void ReceiveMessage(Message message)
    {
        throw new NotImplementedException();
    }
}

