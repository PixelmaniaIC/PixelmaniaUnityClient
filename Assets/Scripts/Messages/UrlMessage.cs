using System;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class UrlMessage
    {
        public string url;

        public UrlMessage(string url)
        {
            this.url = url;
        }

        public static UrlMessage Build(string payload)
        {
            return JsonUtility.FromJson<UrlMessage>(payload);
        }
    }
}