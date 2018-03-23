using Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Receivables
{
    public class UrlReceiver : MonoBehaviour, IReceivable
    {
        public ImageManager ImageManager;
        
        public string NetworkName
        {
            get { return "UrlReceiver"; }
        }

        public void ReceiveMessage(Message message)
        {
//            var parsedMessage = UrlMessage.Build(message.payload);
            ImageManager.StartCoroutine("DownloadImage",
                message.payload);
        }
    }
}