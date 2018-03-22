using Messages;
using UnityEngine;

namespace Assets.GameObjects
{
    public class PlayerIdProcessor : MonoBehaviour, IReceivable
    {
        public string NetworkName
        {
            get { return "PlayerIdProcessor"; }
        }

        public void ReceiveMessage(Message message)
        {
            PlayerId.instance.val = message.playerId.ToString();
            Debug.LogWarning(PlayerId.instance.val);
        }
    }
}