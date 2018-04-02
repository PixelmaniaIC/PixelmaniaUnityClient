using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour {

	// Use this for initialization
	public Color ForegroundColor;
	private SpriteRenderer _spriteRenderer;
	private bool _isActive;
	private int Width = 128;
	private int Height = 128;
	private float lastTime = 0f;

	private void Awake()
	{
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

	public void SetTexture()
	{
		var initTexture = new Texture2D(Width, Height);

		for (var i = 0; i < Width; i++)
		{
			for (var j = 0; j < Height; j++)
			{
				initTexture.SetPixel(i, j, ForegroundColor);
			}
		}

		initTexture.Apply();
		_spriteRenderer.sprite = Sprite.Create(initTexture, new Rect(0, 0, Width, Height), new Vector2(0.5f, 0.5f));
		
		_isActive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		lastTime += Time.deltaTime;
		if (_isActive && lastTime >= 1f)
		{
			var r = _spriteRenderer.material.color.r;
			var g = _spriteRenderer.material.color.g;
			var b = _spriteRenderer.material.color.b;
			var a = _spriteRenderer.material.color.a;
			_spriteRenderer.material.color = new Color(r, g, b, a - 0.05f);	
		}

		if (_spriteRenderer.material.color.a <= 0)
		{
			Destroy(gameObject);
		}
	}
}
