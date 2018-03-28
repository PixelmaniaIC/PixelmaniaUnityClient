using System;
using Messages;
using System.Collections;
using UnityEngine;
using Vuforia;

namespace Assets
{
    public class ImageSquare : MonoBehaviour
    {
        public int Index;
        public Texture2D ImageTexture;
        public Color ForegroundColor;
        public ColorState ColorState;
        public GameObject Prompt;
        
        public int Width = 128;
        public int Height = 128;
        public Vector3 Position;
        
        private bool _isClosed;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;
        private float _lastUpdate = 0f;
        private Touch _touch;
        private int _hitCounter = 0;
        private Texture2D _initColoredTexture;
        private Texture2D _cachedInitImageTexture;
        
        private void Awake()
        {
            Application.runInBackground = true;
            _collider = gameObject.GetComponent<BoxCollider2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            var initTexture = new Texture2D(Width, Height);
            _spriteRenderer.sprite = Sprite.Create(initTexture, new Rect(0, 0, Width, Height), new Vector2(0.5f, 0.5f));
            _isClosed = true;
            Position = transform.position;
        }

        public void SetColliderTo(bool isEnabled)
        {
            _collider.enabled = isEnabled;
        }
 
        IEnumerator SingleOrDouble(){
            Debug.Log("HotCoroutine");
            yield return new WaitForSeconds(0.2f);
            if (_touch.tapCount == 2)
            {
                _hitCounter++;
                if (_hitCounter == 2)
                {
                    _hitCounter = 0;
                    PopUpPrompt();
                }
            }
            else if (_touch.tapCount == 1 || _touch.tapCount >= 3) {
                Debug.Log ("HotTouchSingle");
                SendColorsToServer();
                StopCoroutine("SingleOrDouble");
                _lastUpdate = 0;
            }
        }

        private void PopUpPrompt()
        {
            var prompt = Instantiate(Prompt, Position, Quaternion.identity);
            prompt.transform.parent = this.transform.parent;
            
            var promptScript = prompt.GetComponent<PromptScript>();
            promptScript.ForegroundColor = ForegroundColor;
            promptScript.SetTexture();
            
            Debug.Log("Instantiated Prompt");
        }

        void OnMouseDown()
        {
            if (Input.touchCount > 0) 
            {
                _lastUpdate += Time.deltaTime;
                Debug.Log("HotTouch  " + _lastUpdate);
                _touch = Input.GetTouch(0);
                if (_lastUpdate < 0.2f)
                {
                    StartCoroutine("SingleOrDouble");
                }
                else
                {
                    _lastUpdate = 0.0f;
                }
            }
        }

        public void SendColorsToServer()
        {
            var payload = new SquarePayload(ColorState.CurrentColor, Index);
            var msg = new Message(PlayerId.instance.id, "ColorChanger", payload.ToString());
            TcpUnityClient.instance.SendServerMessage(msg);
        }

        public void UpdateForgroundColor()
        {
            _initColoredTexture = new Texture2D(Width, Height);
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    _initColoredTexture.SetPixel(i, j, ForegroundColor);
                }
            } 
//            _cachedInitImageTexture.SetPixels(_initColoredTexture.GetPixels());
            _initColoredTexture.Apply();
            _spriteRenderer.sprite = Sprite.Create(_initColoredTexture, new Rect(0, 0, Width, Height),
                new Vector2(0.5f, 0.5f));
        }

        private void SetPictureTexture()
        {
            if (_isClosed)
            {
                _cachedInitImageTexture = new Texture2D(Width, Height);
                _cachedInitImageTexture.SetPixels(ImageTexture.GetPixels());
                _cachedInitImageTexture.Apply();
                
                _spriteRenderer.sprite = Sprite.Create(ImageTexture, new Rect(0, 0, Width, Height),
                    new Vector2(0.5f, 0.5f));
                _isClosed = !_isClosed;
            }
        }
        
        public void ApplyReceivedColor(Color color)
        {
            SetPictureTexture();
            var r = (ForegroundColor.r - color.r) * 3;
            var g = (ForegroundColor.g - color.g) * 3;
            var b = (ForegroundColor.b - color.b) * 3;
            
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var current = _cachedInitImageTexture.GetPixel(i, j);
                    var updatedColor = new Color(Mathf.Min(current.r + r, 1), Mathf.Min(current.g + g, 1), Mathf.Min(current.b + b, 1));
                    ImageTexture.SetPixel(i, j, updatedColor);
                }
            }
            
            Debug.Log("Error = " + (r + g + b));
            ImageTexture.Apply();
        }
    }
}