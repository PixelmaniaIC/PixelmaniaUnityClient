using System.IO;
using Messages;
using UnityEngine;

public class ImageHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var msg = new Message(PlayerId.instance.id, "picture", "picture");
		TcpUnityClient.instance.SendServerMessage(msg);
//		UpdateImage(null);
		GetComponent<Renderer>().material.color = Color.red;
	}
	
	public void UpdateImage(byte[] image)
	{
		
//		Debug.Log("Updating Sprite with received message");
//		var tex = new Texture2D(512, 512);
//		tex.LoadImage(image);
//		GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0, 0, 512, 512), new Vector2(0, 0));	
	}
	
	public static Texture2D ReadImage()
	{
		var fileInfo = new FileInfo(@"C:\Users\Artur\Desktop\PixelmaniaUnityClient\Assets\image.jpg");
		var data = new byte[fileInfo.Length];

		using (var stream = fileInfo.OpenRead())
		{
			stream.Read(data, 0, data.Length);
		}

		Texture2D t = new Texture2D(512, 512);
		t.LoadImage(data);
		return t;
	}

}
