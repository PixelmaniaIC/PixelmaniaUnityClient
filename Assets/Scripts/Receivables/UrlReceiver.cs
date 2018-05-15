using Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Receivables
{
    public class UrlReceiver : MonoBehaviour, IReceivable
    {
        public ImageManager ImageManager;

        public FactsPanelUI panel;

        public Text description;
        public Text title;

        public string NetworkName
        {
            get { return "UrlReceiver"; }
        }

        public void ReceiveMessage(Message message)
        {
            UrlMessage urlMessage = UrlMessage.Build(message.payload);
            if (urlMessage.description != null)
            {
                description.text = urlMessage.description.Replace("\\n", "\n");
            }
            title.text = urlMessage.title;

            panel.Link= urlMessage.refLink;

            ImageManager.StartCoroutine("DownloadImage",
                urlMessage.url);
        }
    }
}