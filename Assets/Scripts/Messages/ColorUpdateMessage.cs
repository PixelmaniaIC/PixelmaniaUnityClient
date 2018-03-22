using System;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class ColorUpdateMessage
    {
        public float r;
        public float g;
        public float b;

        public ColorUpdateMessage(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public ColorUpdateMessage(Color color)
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }

        public static ColorUpdateMessage Build(string payload)
        {
            return JsonUtility.FromJson<ColorUpdateMessage>(payload);
        }
    }
}