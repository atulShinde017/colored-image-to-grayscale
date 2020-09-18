using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class ExtensionMethods
{
    public static void Grayscale(this Image image)
    {
        Texture2D oldTexture = image.sprite.texture;
        Texture2D newTexture = new Texture2D(oldTexture.width, oldTexture.height);

        for (int i = 0; i < newTexture.width; i++)
        {
            for (int j = 0; j < newTexture.height; j++)
            {
                Color oldColor = oldTexture.GetPixel(i, j);
                float avg = ((oldColor.r + oldColor.g + oldColor.b) / 3);
                Color color = new Color(avg, avg, avg, oldColor.a);
                newTexture.SetPixel(i, j, color);
            }
        }

        newTexture.Apply();
        Sprite sprite = Sprite.Create(newTexture, new Rect(0.0f, 0.0f, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f), 100f); ;
        image.sprite = sprite;
    }
}
