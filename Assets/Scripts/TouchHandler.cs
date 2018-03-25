using Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public Transform colorPicker;
    public Transform colorState;

    private TcpUnityClient _client;
    private ColorState _colorState;
    private RandomColorChanger _colorChanger;
    private Animator _animatior;

    void Start()
    {
        _client = TcpUnityClient.instance;
        _colorState = colorState.GetComponent<ColorState>();
        _colorChanger = colorPicker.GetComponent<RandomColorChanger>();
        _animatior = colorState.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            if (_colorState.GetComponent<MeshRenderer>().enabled)
            {
                _animatior.Play("Disappearing");
            }

            Color selectedColor = _colorChanger.color;
            _colorState.ColorUpdate(selectedColor);
            // TODO optimize
            _colorState.GetComponent<MeshRenderer>().enabled = true;

//            var payload = new ColorUpdateMessage(selectedColor);
//            var payloadJson = JsonUtility.ToJson(payload);
//
//            var message = new Message(PlayerId.instance.id, "ColorChanger", payloadJson);
//            _client.SendServerMessage(message);

            Debug.Log("Color selected " + selectedColor);
        }
    }
}