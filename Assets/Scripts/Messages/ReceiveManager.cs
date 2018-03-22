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
            if (message == null)
            {
                Debug.LogWarning("Empty message cought");
            }
            else
            {
                Debug.LogWarning(jsonMessage);
                var receiveable = _receivables.First(x => x.NetworkName == message.networkName);

                if (receiveable == null)
                {
                    Debug.LogError(string.Format("Unit with name {0} Not Found", message.networkName));
                }
                else
                {
                    receiveable.ReceiveMessage(message);
                }
            }
        }
    }
}