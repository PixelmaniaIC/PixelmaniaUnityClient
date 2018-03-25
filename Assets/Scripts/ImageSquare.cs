using System;
using Messages;
using UnityEngine;

namespace Assets
{
    public class ImageSquare : MonoBehaviour
    {
        public int Index;
        public Texture2D Texture;
        public Color ForegroundColor;
        public ColorState ColorState;
        
        public int Width = 128;
        public int Height = 128;
        
        private bool _isClosed;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            Application.runInBackground = true;
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            var initTexture = new Texture2D(Width, Height);
            _spriteRenderer.sprite = Sprite.Create(initTexture, new Rect(0, 0, Width, Height), new Vector2(0.5f, 0.5f));
        }

        public void OnTouch()
        {   
            SendColorsToServer();
        }

        public void SendColorsToServer()
        {
            var payload = new SquarePayload(ColorState.CurrentColor, Index);
            var msg = new Message(PlayerId.instance.id, "ColorChanger", payload.ToString());
            TcpUnityClient.instance.SendServerMessage(msg);
        }

        public void UpdateForgroundColor()
        {
            var texture = new Texture2D(Width, Height);
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    texture.SetPixel(i, j, ForegroundColor);
                }
            } 
            texture.Apply();
            _spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, Width, Height),
                new Vector2(0.5f, 0.5f));
        }

        public void ApplyReceivedColor(Color color)
        {
            _spriteRenderer.sprite = Sprite.Create(Texture, new Rect(0, 0, Width, Height),
                new Vector2(0.5f, 0.5f));
            
            var r = (ForegroundColor.r - color.r) * 3;
            var g = (ForegroundColor.g - color.g) * 3;
            var b = (ForegroundColor.b - color.b) * 3;
            
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var current = Texture.GetPixel(i, j);
                    var updatedColor = new Color(Mathf.Min(current.r + r, 1), Mathf.Min(current.g + g, 1), Mathf.Min(current.b + b, 1));
                    Texture.SetPixel(i, j, updatedColor);
                }
            }
            
            Debug.Log("Error = " + (r + g + b));
            Texture.Apply();
        }
    }
}