using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Camera follows the player from a fixed distance
public class FollowerCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private float finishLine = 150f;

    void Update()
    {
        if (transform.position.z < finishLine-10)
        {
            transform.position = target.position + offset;
        }
    }

}
