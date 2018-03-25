using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorState : MonoBehaviour {

    private Renderer _render;
	public Color32 CurrentColor;
	
	void Start () {
        _render = gameObject.GetComponent<Renderer>();
		// Init state of Color state
		CurrentColor = Color.blue;
        _render.material.color = Color.blue;
	}

	public void ColorUpdate(Color32 color)
	{
		Debug.Log ("Switching color");
		CurrentColor = color;
		_render.material.color = color;	
	}
}
