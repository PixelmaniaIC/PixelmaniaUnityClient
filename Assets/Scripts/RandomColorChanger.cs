using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Assets;
using UnityEngine;
using UnityEngine.UI;

// TODO: why this name?
public class RandomColorChanger : MonoBehaviour {

	// Use this for initialization

	public Color color;
    private Image picture;

	void Start () {
		color = Color.green;
        picture = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Debug.Log("Received color " + color);

        // TODO: optimize this!
        // TODO: sorry for my parents
        color = gameObject.transform.parent.parent.parent.GetComponent<CameraAccess>().Color;
        picture.color = color;
	}
}
