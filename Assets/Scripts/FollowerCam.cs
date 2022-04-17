using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private float finishLine = 150f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < finishLine)
        {
            transform.position = target.position + offset;
        }
    }

}
