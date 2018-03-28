using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;
using System;

public class UserScoreUpdater : MonoBehaviour, IReceivable
{
    public Leaderboard leaderboard;

    public string NetworkName
    {
        get { return "ScoreUpdater"; }
    }

    public void ReceiveMessage(Message message)
    {
        leaderboard.UpdateScore(message.playerId, Int32.Parse(message.payload));
    }
}
