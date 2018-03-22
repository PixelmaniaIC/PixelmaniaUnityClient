using Messages;
using UnityEngine;

namespace Assets.GameObjects
{
    public class ColorReceiver : MonoBehaviour, IReceivable
    {
        public ColorState colorState;

        public string NetworkName
        {
            get { return "ColorChanger"; }
        }

        public void ReceiveMessage(Message message)
        {
            var parsedMessage = ColorUpdateMessage.Build(message.payload);
            Color selectedColor = new Color(parsedMessage.r, parsedMessage.g, parsedMessage.b);
            colorState.ColorUpdate(selectedColor);
        }
    }
}