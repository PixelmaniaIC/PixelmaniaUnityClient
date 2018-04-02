using Assets;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorChanger : MonoBehaviour {

	// Use this for initialization

	public Color color;
	public CameraAccess _cameraAccess;

    private Image picture;
	
	void Start () {
		color = Color.green;
        picture = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        color = _cameraAccess.Color;
        picture.color = color;
	}
}
