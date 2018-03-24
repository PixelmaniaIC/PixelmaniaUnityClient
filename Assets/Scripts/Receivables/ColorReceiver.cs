using Messages;
using UnityEngine;

namespace Assets.GameObjects
{
    public class ColorReceiver : MonoBehaviour, IReceivable
    {
        public ImageManager ImageManager;

        public string NetworkName
        {
            get { return "ColorChanger"; }
        }

        public void ReceiveMessage(Message message)
        {
            var parsedMessage = ColorUpdateMessage.Build(message.payload);
            var selectedColor = new Color32((byte)parsedMessage.r, (byte)parsedMessage.g, (byte)parsedMessage.b, 255);
            ImageManager.ApplyColor(selectedColor, parsedMessage.index);
        }
    }
}