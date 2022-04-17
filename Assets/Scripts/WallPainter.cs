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
    private float finishLine = 150f;
    public float camAngle;
    public float parentAngle;
    public float camLocalAngle;

    void Start()
    {
        cam = GetComponent<Camera>();
        perText.text = "";
    }

    void Update()
    {
      

        if (transform.position.z > finishLine - 20)
        {
            
            if (!Input.GetMouseButton(0))
                return;
            
            RaycastHit hit;
            if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
                return;

            Renderer rend = hit.transform.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;
            Debug.Log("vurdu");

            if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                return;

            tex = rend.material.mainTexture as Texture2D;
            Color[] pixels = tex.GetPixels(0);

            Debug.Log("deneme");


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


            Debug.Log("redpercent" + redPercent);
            tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.red);
            tex.Apply();

        }
        //if ( transform.eulerAngles.y!=0)
        //{
        //    // transform.eulerAngles = transform.parent.eulerAngles- new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        //    //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        //}

       // transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

       // camAngle = transform.eulerAngles.y;
       // parentAngle = transform.parent.eulerAngles.y;

        //camLocalAngle = transform.localEulerAngles.y;  

       // transform.parent
    }
}