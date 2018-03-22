using System.Collections;
using System.Collections.Generic;
using Messages;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    Renderer render = null;

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
    }
	
    public void UpdateColor(float r, float g, float b)
    {
        render.material.color = new Color(r, g, b);
    }
}
