using UnityEngine;

namespace Assets
{
    public class ImageSquare : MonoBehaviour
    {
        public int width;
        public int height;

        private bool _isClosed;
        private Color _foregroundColor;
        public int Index;
        public Texture2D texture;

        public ImageSquare(int index, int posX, int posY) 
        {
            Index = index;
        }

        private void Awake()
        {
            var initTexture = new Texture2D(128, 128);
            GetComponent<SpriteRenderer>().sprite = Sprite.Create(initTexture, new Rect(0, 0, 128, 128), new Vector2(0.5f, 0.5f));
        }

        private void OnMouseDown()
        {
            GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, 128, 128),
                new Vector2(0.5f, 0.5f));
        }
    }
}