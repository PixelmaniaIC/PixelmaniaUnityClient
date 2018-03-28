using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;

//This class receives current state of users in the beginning of the game
public class UsersInitializer : MonoBehaviour, IReceivable {
    public Leaderboard leaderboard;

    public string NetworkName
    {
        get { return "UsersInitializer"; }  
    }

    public void ReceiveMessage(Message message)
    {
        LeaderboardMessage ldbMessage = LeaderboardMessage.Build(message.payload);
        ldbMessage.users.ForEach(user => leaderboard.AddUser(user));
    }
}
