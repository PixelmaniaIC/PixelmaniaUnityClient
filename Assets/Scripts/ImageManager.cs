using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assets;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public Transform ImageSquare;

    public int ImageWidth = 128;
    public int ImageHeight = 128;
    public float ImageXOffset;
    public float ImageYOffset;
    private List<ImageSquare> _squares;

    private void Start()
    {
        ImageXOffset = ImageWidth / 100f;
        ImageYOffset = ImageHeight / 100f;        
        CreateSquares();
    }

    IEnumerator DownloadImage(string url)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            SetTexture(www.texture);
        }
    }

    private void CreateSquares()
    {
        _squares = new List<ImageSquare>();

        var posX = -1f;
        var posY = 2f;

        for (var i = 0; i < 4; i++)
        {
            posX = -3f;
            for (var j = 0; j < 4; j++)
            {
                var obj = Instantiate(ImageSquare, new Vector3(posX, posY, 0), Quaternion.identity);
                obj.parent = this.transform;
                
                var square = obj.GetComponent<ImageSquare>();
                square.Index = 4 * i + j;
                _squares.Add(square);
                
                posX += ImageXOffset;
            }
            posY -= ImageYOffset;
        }
    }

    public void SetTexture(Texture2D texture)
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                var squareNum = (12 + j) - i * 4;
                var square = _squares[squareNum];
                
                var colorBlock = texture.GetPixels(ImageWidth * j, ImageHeight * i, ImageWidth, ImageHeight);
                var appliedTexture = new Texture2D(ImageWidth, ImageHeight);
                
                appliedTexture.SetPixels(colorBlock);
                appliedTexture.Apply();
                
                var averageR = colorBlock.Average(x => x.r);
                var averageG = colorBlock.Average(x => x.g);
                var averageB = colorBlock.Average(x => x.b);
                Debug.Log("R = " + averageR + " G = " + averageG + " B = " + averageB);
                
                square.Texture = appliedTexture;
                square.ForegroundColor = new Color(averageR, averageG, averageB);
                square.UpdateForgroundColor();
            }
        }
    }

    public void ApplyColor(Color color, int index)
    {
        _squares[index].ApplyReceivedColor(color);
    }

    public void SetForegroundColors()
    {
        _squares[1].UpdateForgroundColor();
    }

}