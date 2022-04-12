using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorRotate : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotatorSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //slerp: smooth iþleri
        //dönüyor ve vuruyor - kuvvet de uygulasa tatlý olur
        transform.Rotate(0, rotatorSpeed, 0);
        // kuvvet uygulamasý da eklenecek
        //eðer bu ikisi çarpýþtýysa diyeceðiz, add force yapacaðýz. zaten fiziksel obje
        //o yüzden çalýþýr bence
    }
}
