using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;
using System;

public class UserScoreUpdater : MonoBehaviour, IReceivable
{
    public Leaderboard leaderboard;
    public ImageManager ImageManager;

    public string NetworkName
    {
        get { return "ScoreUpdater"; }
    }

    public void ReceiveMessage(Message message)
    {
        var payload = ScoreUpdate.Build(message.payload);
        leaderboard.UpdateScore(message.playerId, payload.score);
        ImageManager.PopUpScores(payload.score, payload.index);
    }
}
