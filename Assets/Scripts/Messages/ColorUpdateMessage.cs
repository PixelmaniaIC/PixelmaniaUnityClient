using System;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class ColorUpdateMessage
    {
        public int r;
        public int g;
        public int b;
        public int index;

        public static ColorUpdateMessage Build(string payload)
        {
            return JsonUtility.FromJson<ColorUpdateMessage>(payload);
        }
    }
}