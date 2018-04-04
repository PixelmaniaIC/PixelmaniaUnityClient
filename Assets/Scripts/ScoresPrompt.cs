using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresPrompt : MonoBehaviour {

	// Use this for initialization

	private TextMesh _textMesh;
	private bool _isIncreasing;
	private float lastTime = 0f;

	
	void Awake ()
	{
		_isIncreasing = true;
		_textMesh = gameObject.GetComponent<TextMesh>();
	}

	void Update()
	{
		lastTime += Time.deltaTime;
		if (_isIncreasing)
		{
			_textMesh.characterSize += 0.25f;
		}
		else
		{
			var current = _textMesh.color;
			current.a -= 0.05f;
			
			_textMesh.characterSize -= 0.05f;
			_textMesh.color = current;
			
			if (_textMesh.characterSize <= 0)
			{
				Destroy(gameObject);
			}
		}
		
		if (lastTime >= 0.1f)
		{
			_isIncreasing = false;
		}
	}
	
	public void ShowReceivedScore(int scores)
	{
		Debug.Log("Setting scores to " + scores);
		if (scores > 0)
		{
			_textMesh.color = Color.green;
			_textMesh.text = "+" + scores;
		}
		else
		{
			_textMesh.color = Color.red;
			_textMesh.text = scores.ToString();			
		}
	}
}
