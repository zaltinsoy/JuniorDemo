using UnityEngine;
using System.Collections;

public class WallColor : MonoBehaviour
{
    Texture2D texture;

    void Awake()
    {
        texture = new Texture2D(256, 256);
        GetComponent<Renderer>().material.mainTexture = texture;

        // Apply initial color to the wall
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = Color.blue;
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }


}