using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    private float rotationSpeed = 10f;
    private float horizontalSpeed = 7f; //5ti bu

    public GameObject gamePlatform;
    public float leftBorder;
    public float rightBorder;

    void Start()
    {
        rightBorder = gamePlatform.transform.localScale.z / 4;
        leftBorder = -rightBorder;
    }
  
    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
        transform.position = transform.position + new Vector3(horizontalSpeed * Time.fixedDeltaTime, 0, 0);

        if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(rightBorder-0.1f, transform.position.y, transform.position.z);
            horizontalSpeed = -horizontalSpeed;
        }
        else if (transform.position.x < leftBorder)
        {
            //Move slighly to the right, otherwise it may stuck in one end
            transform.position = new Vector3(leftBorder + 0.1f, transform.position.y, transform.position.z);
            horizontalSpeed = -horizontalSpeed;
        }

    }
}

