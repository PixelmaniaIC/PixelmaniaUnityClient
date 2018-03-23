using Messages;
using UnityEngine;

namespace Receivables
{
    public class ImageReceiver : MonoBehaviour, IReceivable
    {
        public ImageManager imageHandler;
        
        public string NetworkName
        {
            get { return "ImageReceiver"; } 
        }

        public void ReceiveMessage(Message message)
        {
            Debug.Log("Received image " + message.networkName);
            var image = ImagePayload.Build(message.payload).imageBytes;
            imageHandler.StartCoroutine("DownloadImage", "http://res.cloudinary.com/df0xbva5c/image/upload/v1521716516/randevu.png");
        }
    }
}