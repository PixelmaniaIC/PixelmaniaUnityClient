using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : IdReceiveListener {

    public LeaderboardDrawer leaderboardDrawer;

    private List<User> _users = new List<User>();

    // Принцесса, эту часть удали, это просто для тестинга
    /*public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddUser(new User(i.ToString(), "Bitch" + i.ToString(), i * 10, true));
            i++;
        }
    }*/

    // Initializing current user. It should be in separate class
    public override void OnIdReceived()
    {
        var currentUser = new User(PlayerId.instance.id, TcpUnityClient.instance.name, 0, true);
        AddUser(currentUser);        
    }

    public void AddUser(User user)
    {
        _users.Add(user);

        leaderboardDrawer.UpdateLeaderboard(_users);
    }

    public void OfflineUser(string id)
    {
        _users.Find(x => x.id == id).online = false;

        leaderboardDrawer.UpdateLeaderboard(_users);
    }

    public void UpdateScore(string id, int score)
    {
        _users.Find(x => x.id == id).score += score;

        leaderboardDrawer.UpdateLeaderboard(_users);
    }

    public List<User> GetUsers()
    {
        return _users;
    }
}
