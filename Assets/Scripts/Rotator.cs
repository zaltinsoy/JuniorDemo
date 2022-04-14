using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotatorSpeed = 5f;
   
    private void FixedUpdate()
    {
        //slerp: smooth iþleri
        //dönüyor ve vuruyor - kuvvet de uygulasa tatlý olur
        transform.Rotate(0, rotatorSpeed, 0);
    }

}
