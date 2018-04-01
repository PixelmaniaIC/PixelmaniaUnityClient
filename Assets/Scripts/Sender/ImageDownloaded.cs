using Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDownloaded : MonoBehaviour {

    public void OnImageDownloaded()
    {
        var imageDownloaded = new Message(PlayerId.instance.id, "ImageDownloaded", PlayerId.instance.UserName);
        TcpUnityClient.instance.SendServerMessage(imageDownloaded);
    }
}
