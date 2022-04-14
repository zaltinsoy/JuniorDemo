using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Paintable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray,out hit))
            {
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity,transform);
                go.transform.localScale = Vector3.one * BrushSize;
            }
            //mouse position'dan ray atýyor
        }
    }
    public void Save()
    {
        
        StartCoroutine(CoSave());


    }
    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath);

        RenderTexture.active = RTexture;
        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        //texture tanýmladýk bu güzelmiþ
        texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        texture2D.Apply();
        var data = texture2D.EncodeToPNG(); ;
        File.WriteAllBytes(Application.dataPath + "/savedImage.png",data);
    }
}
