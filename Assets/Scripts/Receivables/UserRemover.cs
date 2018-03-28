using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;

public class UserRemover : MonoBehaviour, IReceivable
{
    public Leaderboard leaderboard;

    public string NetworkName
    {
        get { return "UserRemover"; }
    }

    public void ReceiveMessage(Message message)
    {
        string exitUserId = message.payload;
        leaderboard.OfflineUser(exitUserId);
    }
}
