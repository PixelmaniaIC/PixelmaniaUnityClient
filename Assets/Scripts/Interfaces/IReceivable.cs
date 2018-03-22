using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;

public interface IReceivable
{
    string NetworkName { get; }
    void ReceiveMessage(Message message);
}
