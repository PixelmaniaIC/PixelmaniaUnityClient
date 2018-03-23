using System;
using UnityEngine;

namespace Messages
{
    [Serializable]
    public class ImagePayload
    {

        public byte[] imageBytes;

        public ImagePayload(byte[] _imageBytes)
        {
            imageBytes = _imageBytes;
        }
        
        public static ImagePayload Build(string payload)
        {
            return JsonUtility.FromJson<ImagePayload>(payload);
        }
    }
}