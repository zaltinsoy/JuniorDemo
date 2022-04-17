using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Rotates at fixed speed
public class Rotator : MonoBehaviour
{
    private float rotatorSpeed = -5f;
   
    private void FixedUpdate()
    {
        transform.Rotate(0, rotatorSpeed, 0);
    }

}
