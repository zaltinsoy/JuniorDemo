using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Rotating on a fixed speed
public class HalfDonut : MonoBehaviour
{
    private float rotatorSpeed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate( rotatorSpeed,0, 0);

    }

}
