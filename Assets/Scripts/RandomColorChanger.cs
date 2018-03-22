using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Assets;
using UnityEngine;

// TODO: why this name?
public class RandomColorChanger : MonoBehaviour {

	// Use this for initialization

	public Color color;
    private Renderer _render;

	void Start () {
		this.color = Color.green;
        _render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Received color " + color);

        // TODO: optimize this!
		color = this.gameObject.transform.parent.GetComponent<CameraAccess>().Color;
        _render.material.color = color;
	}
}
