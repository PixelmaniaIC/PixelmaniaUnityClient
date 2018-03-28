using System;
using System.Collections.Generic;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class LeaderboardMessage
    {
        [SerializeField]
        public List<User> users;

        public static LeaderboardMessage Build(string payload)
        {
            Debug.Log("Payload received " + payload);
            return JsonUtility.FromJson<LeaderboardMessage>(payload);
        }
    }
}