using System;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class UrlMessage
    {
        public string url;
        public string title;
        public string description;
        public string refLink;

        public UrlMessage(string url, string description, string refLink, string title)
        {
            this.url = url;
            this.description = description;
            this.refLink = refLink;
            this.title = title;
        }

        public static UrlMessage Build(string payload)
        {
            return JsonUtility.FromJson<UrlMessage>(payload);
        }
    }
}