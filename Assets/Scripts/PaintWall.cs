using UnityEngine;
using System.Collections;

public class PaintWall : MonoBehaviour
{
    Texture2D texture;
    void Awake()
    {
        texture = new Texture2D(128, 256);
        GetComponent<Renderer>().material.mainTexture = texture;
     //   GetComponent<SpriteRenderer>().material.mainTexture = texture;



        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = ((x & y) != 0 ? Color.blue : Color.red);
                
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
    
    private void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
        //it works
       // Texture2D texture = new Texture
    }
    private void Update()
    {
        texture.Apply();
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}