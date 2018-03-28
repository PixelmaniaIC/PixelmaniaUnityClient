using System.Collections.Generic;

public class Leaderboard : IdReceiveListener {

    private List<User> _users = new List<User>();

    // Initializing current user. It should be in separate class
    public override void OnIdReceived()
    {
        var currentUser = new User(PlayerId.instance.id, TcpUnityClient.instance.name, 0, true);
        AddUser(currentUser);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void OfflineUser(string id)
    {
        _users.Find(x => x.id == id).online = false;
    }

    public void UpdateScore(string id, int score)
    {
        _users.Find(x => x.id == id).score += score;
    }
}
