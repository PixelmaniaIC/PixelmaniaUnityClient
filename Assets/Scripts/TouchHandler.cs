using Messages;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngineInternal;

public class TouchHandler : MonoBehaviour
{
    public Transform colorPicker;
    public Transform colorState;
    public bool IsTracking;
    
    private TcpUnityClient _client;
    private ColorState _colorState;
    private RandomColorChanger _colorChanger;
    private Animator _animatior;
    private MeshRenderer _meshRender;
    private Camera _camera;

    void Start()
    {
        IsTracking = false;
        _client = TcpUnityClient.instance;
        _colorState = colorState.GetComponent<ColorState>();
        _colorChanger = colorPicker.GetComponent<RandomColorChanger>();
        _animatior = colorState.GetComponent<Animator>();
        _camera = GetComponent<Camera>();
        _meshRender = _colorState.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (!IsTracking)
            {
                if (_meshRender.enabled)
                {
                    _animatior.Play("Disappearing");
                }
                else
                {
                    _meshRender.enabled = true;
                }

                Color selectedColor = _colorChanger.color;
                _colorState.ColorUpdate(selectedColor);
            }
        }
    }
}