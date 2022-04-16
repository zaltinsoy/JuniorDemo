using UnityEngine;
using System.Collections;

public class PaintWall : MonoBehaviour
{
    // The force with which the target is "poked" when hit.
    float pokeForce;
    Texture2D texture;
    

    void Awake()
    {
        texture = new Texture2D(256, 256);
        GetComponent<Renderer>().material.mainTexture = texture;
     //   GetComponent<SpriteRenderer>().material.mainTexture = texture;


        // Apply initial color to the wall
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                //Color color = ((x & y) != 0 ? Color.blue : Color.red);
                Color color = Color.blue;  

                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
    /*
    private void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().material.color = Color.blue;
        //it works
       // Texture2D texture = new Texture
    }
    */
    /*
    private void Update()
    {
        texture.Apply();
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
    */
    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(ray.direction * pokeForce, hit.point);
                }
            }
        }
    }
    */
    private void Update()
    {
        //Debug.Log(texture.GetPixel(x, y, Color));
        //texture.GetPixel(5,5,)
          //  Color[] pixels = texture.GetPixels(SourceMipLevel);
    }
}