using System.Collections.Generic;
using Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Receivables
{
    public class ImageInitializer : MonoBehaviour, IReceivable
    {

        public ImageManager ImageManager;
        
        public string NetworkName
        {
            get { return "ImageInitializer"; }
        }
        public void ReceiveMessage(Message message)
        {
            var boxes = ColorBoxMessage.Build(message.payload);
            ImageManager.ReceiveColors(boxes);    
        }
    }
}