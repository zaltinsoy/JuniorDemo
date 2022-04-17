using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System;

public class WallPainter : MonoBehaviour
{
    public Texture2D tex;

    public Camera cam;
    public float[] colorSum;
    public Text perText;
    public GameObject playerBoy;
    public float endGame;
    private float finishLine = 150f;


    void Start()
    {
        cam = GetComponent<Camera>();
        perText.text = "";
    }

    void Update()
    {

        if (transform.position.z > finishLine - 10)
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

            tex = rend.material.mainTexture as Texture2D;
            Color[] pixels = tex.GetPixels(0);

            // Convert color information to grayscale
            float[] floatArray = new float[pixels.Length];
            for (int i = 0; i < pixels.Length; i++)
            {
                floatArray[i] = pixels[i].grayscale;
            }

            // Count the number of pixels with specified color
            double redColor = floatArray.Count(s => s < 0.150);
            double blueColor = floatArray.Count(s => s > 0.150);
            double redPercent = blueColor / (redColor + blueColor) * (100d);
            // Update the text
            perText.text = "Red: %" + redPercent.ToString("0.#");

            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.red);
            tex.Apply();

        }

    }
}