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
        //slerp: smooth i�leri
        //d�n�yor ve vuruyor - kuvvet de uygulasa tatl� olur
        transform.Rotate(0, rotatorSpeed, 0);
        // kuvvet uygulamas� da eklenecek
        //e�er bu ikisi �arp��t�ysa diyece�iz, add force yapaca��z. zaten fiziksel obje
        //o y�zden �al���r bence
    }
}
