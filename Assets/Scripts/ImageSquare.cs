using Messages;
using UnityEngine;

namespace Assets
{
    public class ImageSquare : MonoBehaviour, IReceivable
    {
        public int Index;
        public Texture2D Texture;
        public Color ForegroundColor;

        public int Width = 128;
        public int Height = 128;
        
        private bool _isClosed;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            var initTexture = new Texture2D(Width, Height);
            _spriteRenderer.sprite = Sprite.Create(initTexture, new Rect(0, 0, Width, Height), new Vector2(0.5f, 0.5f));
        }

        private void OnMouseDown()
        {
            _spriteRenderer.sprite = Sprite.Create(Texture, new Rect(0, 0, Width, Height),
                new Vector2(0.5f, 0.5f));
            
            // TODO REMOVE THIS SHIT
            ApplyReceivedColor(Color.gray);
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
            var r = ForegroundColor.r - color.r;
            var g = ForegroundColor.g - color.g;
            var b = ForegroundColor.b - color.b;
            
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var current = Texture.GetPixel(i, j);
                    var updatedColor = new Color(current.r - r, current.g - g, current.b - b);
                    Texture.SetPixel(i, j, updatedColor);
                }
            }
            
            Texture.Apply();
        }

        public string NetworkName
        {
            get { return "ImageManager"; }
        }

        public void ReceiveMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}