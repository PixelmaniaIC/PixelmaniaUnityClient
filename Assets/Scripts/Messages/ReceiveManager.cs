using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Messages
{
    public class ReceiveManager : MonoBehaviour
    {
        private IEnumerable<IReceivable> _receivables;

        public ReceiveManager(IEnumerable<IReceivable> receivables)
        {
            _receivables = receivables;
        }

        public void Process(string jsonMessage)
        {
            var message = JsonUtility.FromJson<Message>(jsonMessage);

            // TODO:
            if (message != null)
            {
                var receiveable = _receivables.First(x => x.NetworkName == message.networkName);

                if (receiveable != null)
                {
                    receiveable.ReceiveMessage(message);
                }
            }
        }
    }
}