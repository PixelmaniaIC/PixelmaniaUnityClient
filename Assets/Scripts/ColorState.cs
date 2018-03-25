using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorState : MonoBehaviour {

    private Renderer _render;

	// Update is called once per frame
	void Start () {
        _render = gameObject.GetComponent<Renderer>();

        // TODO: what the fuck?
        _render.material.color = Color.blue;
	}

	public void ColorUpdate(Color color)
	{
		Debug.Log ("Switching color");
		_render.material.color = color;	
	}
}
