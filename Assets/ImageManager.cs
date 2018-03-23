using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public Transform ImageSquare;

    public int ImageWidth = 128;
    public int ImageHeight = 128;
    
    private List<Transform> _squares;

    private void Start()
    {
        CreateSquares();
        var www = new WWW("http://res.cloudinary.com/df0xbva5c/image/upload/v1521716516/randevu.png");
        
        while (!www.isDone)
        {
            
        }

        SetTexture(www.texture);
    }

    private void CreateSquares()
    {
        _squares = new List<Transform>();

        var posX = -1f;
        var posY = 2f;

        for (var i = 0; i < 4; i++)
        {
            posX = -3f;
            for (var j = 0; j < 4; j++)
            {
                var obj = Instantiate(ImageSquare, new Vector3(posX, posY, 0), Quaternion.identity);
                obj.parent = this.transform;
                obj.GetComponent<ImageSquare>().Index = 4 * i + j;
                _squares.Add(obj);
                posX += 1.28f;
            }

            posY -= 1.28f;
        }
    }

    public void SetTexture(Texture2D texture)
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                var colorBlock = texture.GetPixels(ImageWidth * j, ImageHeight * i, 128, ImageHeight);
                var appliedTexture = new Texture2D(ImageWidth, ImageHeight);
                appliedTexture.SetPixels(colorBlock);
                appliedTexture.Apply();

                _squares[(12 + j) - i * 4].GetComponent<ImageSquare>().texture =
                    appliedTexture;
//                    Sprite.Create(t, new Rect(0, 0, 128, 128), new Vector2(0.5f, 0.5f));
            }
        }
    }

}