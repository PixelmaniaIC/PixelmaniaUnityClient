using Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedImageInitializer : MonoBehaviour, IReceivable {
    public ImageManager imageManager;

    public string NetworkName
    {
        get { return "ChangedImageInitializer"; }
    }

    public void ReceiveMessage(Message message)
    {
        var boxes = ColorBoxMessage.Build(message.payload);

        boxes.cubes.ForEach(x => imageManager.ApplyColor(GetColor(x), x.index));
    }

    private Color GetColor(SingleColor sColor)
    {
        byte r = (byte)sColor.r;
        byte g = (byte)sColor.g;
        byte b = (byte)sColor.b;

        return new Color32(r, g, b, (byte)255);
    }
}