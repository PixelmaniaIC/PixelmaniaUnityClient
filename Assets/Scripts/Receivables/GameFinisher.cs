using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinisher : MonoBehaviour, IReceivable {
    public List<FinishGameListener> finishGameListeners;

    public string NetworkName
    {
        get { return "GameFinisher"; }
    }

    public void ReceiveMessage(Message message)
    {
        for (var i = 0; i < finishGameListeners.Count; i++)
        {
            finishGameListeners[i].OnGameFinished();
        }
    }
}
