using Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour {

	public Transform colorPicker;
	public Transform colorState;

	private TcpUnityClient _client;
    private ColorState _colorState;
    private RandomColorChanger _colorChanger;

    void Start() {
        _client = TcpUnityClient.instance;
        _colorState = colorState.GetComponent<ColorState>();
        _colorChanger = colorPicker.GetComponent<RandomColorChanger>();

    }

	void Update()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
		{
			Color selectedColor = _colorChanger.color;
			_colorState.ColorUpdate(selectedColor);	
		}
	}
	
}
