using Messages;
using UnityEngine;

namespace Receivables
{
    public class ImageReceiver : MonoBehaviour, IReceivable
    {
        public ImageHandler imageHandler;
        
        public string NetworkName
        {
            get { return "ImageReceiver"; } 
        }

        public void ReceiveMessage(Message message)
        {
            Debug.Log("Received image " + message.networkName);
            var image = ImagePayload.Build(message.payload).imageBytes;
            imageHandler.UpdateImage(image);
        }
    }
}