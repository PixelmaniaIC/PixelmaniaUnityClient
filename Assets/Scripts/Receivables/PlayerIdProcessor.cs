using Messages;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameObjects
{
    public class PlayerIdProcessor : MonoBehaviour, IReceivable
    {
        public List<IdReceiveListener> listeners;

        public string NetworkName
        {
            get { return "PlayerIdProcessor"; }
        }

        public void ReceiveMessage(Message message)
        {
            PlayerId.instance.id = message.playerId.ToString();
            Debug.LogWarning(PlayerId.instance.id);

            listeners.ForEach(x => x.OnIdReceived());
        }
    }
}