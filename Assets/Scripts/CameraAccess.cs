using System.Diagnostics.CodeAnalysis;
using UnityEngine;

//using Vuforia.EditorClasses;

namespace Assets
{
    /**
     * Gets color of center pixel of main Camera
     * Main color accessed through Color public variable
     */
    public class CameraAccess : MonoBehaviour
    {        
        public Color32 Color = new Color(0,0,0);

        private Camera _camera;

        private int _targetWidth;
        private int _targetHeight;
        private int _targetXPixel;
        private int _targetYPixel;

        private Rect _rect;
        private RenderTexture _renderTexture;
        private Texture2D _screenShot;

        private bool _captureScreenshot = false;
        private bool _captureVideo = false;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _targetWidth = Mathf.FloorToInt(Screen.width / 2);
            _targetHeight = Mathf.FloorToInt(Screen.height / 2);
            _targetXPixel = Mathf.FloorToInt(Screen.width / 4);
            _targetYPixel = Mathf.FloorToInt(Screen.height / 4);
        }

        /**
         * Updates are fixed due to minimazing loss of fps
         */
        private void Update()
        {
            
            if (Input.touchCount > 0)
            {
//                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
//                RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
//                if (hit.collider != null) {
//                    Debug.Log (hit.collider.gameObject.name);
//                }
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
                    if (hit.collider != null) {
                        hit.collider.gameObject.GetComponent<ImageSquare>().OnTouch();
                    }
                }
            }
            else
            {
                if (_renderTexture == null)
                {
                    _rect = new Rect(0, 0, _targetWidth, _targetHeight);
                    _renderTexture = new RenderTexture(_targetWidth, _targetHeight, 24);
                    _screenShot = new Texture2D(_targetWidth, _targetHeight, TextureFormat.RGB24, false);
                }

                _camera.targetTexture = _renderTexture;
                _camera.Render();
            
                RenderTexture.active = _renderTexture;
            
                _screenShot.ReadPixels(_rect, 0, 0);
            
                _camera.targetTexture = null;
                RenderTexture.active = null;
            
                Color = _screenShot.GetPixel(_targetXPixel, _targetYPixel);
            
            }
        }
    }
}