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
            var parsedMessage = UrlMessage.Build(message.payload);
            ImageManager.StartCoroutine("DownloadImage",
                "http://res.cloudinary.com/df0xbva5c/image/upload/v1521716516/randevu.png");
        }
    }
}