// Write black pixels onto the GameObject that is located
// by the script. The script is attached to the camera.
// Determine where the collider hits and modify the texture at that point.
//
// Note that the MeshCollider on the GameObject must have Convex turned off. This allows
// concave GameObjects to be included in collision in this example.
//
// Also to allow the texture to be updated by mouse button clicks it must have the Read/Write
// Enabled option set to true in its Advanced import settings.

using UnityEngine;
using System.Collections;
using System.Linq;

public class WallPainter : MonoBehaviour
{
    public Texture2D tex;

    public Camera cam;
    public float[] colorSum; 

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        //burada bir kamera bildirimi alýyorum onu çözmeyece çalýþacaðým
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            return;

        // Texture2D tex = rend.material.mainTexture as Texture2D;
        tex = rend.material.mainTexture as Texture2D;


        int sourceMipLevel = 0;
        Color[] pixels = tex.GetPixels(sourceMipLevel);
        //Debug.Log(pixels);
        //Debug.Log(pixels.Length);
        //colorSum[2]= pixels[2].grayscale;

      // Debug.Log(pixels[26].grayscale);
        float[] floatArray = new float[pixels.Length];
            floatArray[0] = pixels[26].grayscale;
       // Debug.Log(floatArray[0] + 1);
       
        //colorSum[26] = pixels[26].grayscale;
        //Debug.Log(colorSum[26]);

        
        for (int i = 0; i < pixels.Length; i++)
        {
            floatArray[i] = pixels[i].grayscale;
          //  Debug.Log(floatArray[i]+"debene"+i);
        }

        double redColor = floatArray.Count(s => s < 0.150);
        double blueColor = floatArray.Count(s => s > 0.150);
        double redPercent = blueColor /(redColor+blueColor)* (100d);
        Debug.Log(redPercent);

        //Debug.Log("max" + floatArray.Max());
        //Debug.Log("min" + floatArray.Min());

            //hepsini baþka bir yere aktardýk bu sayede
        

        //colorSum[0]=pixels[10].grayscale;
      
        //Debug.Log(colorSum[0]);
        // çalýþýyor burasý



        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.red);

       


     //   Debug.Log(Color[]);


        tex.Apply();
    }
    // burada ölçüm yapmak sýradaki asýl amacýmýz
}