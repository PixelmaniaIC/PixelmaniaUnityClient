using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;

public class UserInserter : MonoBehaviour, IReceivable {
    public Leaderboard leaderboard;

    public string NetworkName
    {
        get { return "UserInserter"; }
    }

    // Initializing entered user
    public void ReceiveMessage(Message message)
    {
        var enteredUser = new User(message.playerId, message.payload, 0, true);
        leaderboard.AddUser(enteredUser);
    }
}
