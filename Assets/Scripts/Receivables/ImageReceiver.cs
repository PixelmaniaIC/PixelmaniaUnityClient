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
            imageHandler.StartCoroutine("DownloadImage", message.payload);
        }
    }
}