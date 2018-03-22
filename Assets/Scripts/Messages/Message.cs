using System;

namespace Messages
{
    [Serializable]
    public class Message
    {
        public string playerId;
        public string networkName;
        public string payload;

        public Message(string playerId, string networkName, string payload)
        {
            this.playerId = playerId;
            this.networkName = networkName;
            this.payload = payload;
        }
    }
}