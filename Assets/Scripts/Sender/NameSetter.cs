using Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSetter : IdReceiveListener {

    public override void OnIdReceived()
    {
        var setNameMessage = new Message(PlayerId.instance.id, "NameSetter", PlayerId.instance.UserName);
        TcpUnityClient.instance.SendServerMessage(setNameMessage);
    }
}
