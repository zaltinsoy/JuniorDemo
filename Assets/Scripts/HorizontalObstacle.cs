using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move horizontal obstacle from one end of the platform to other
// Also rotate on its own axis
public class HorizontalObstacle : MonoBehaviour
{
    private float rotationSpeed = 10f;
    private float horizontalSpeed = 7f; 

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
            //Move slighly to the inside, otherwise it may stuck in one end
            transform.position = new Vector3(rightBorder-0.1f, transform.position.y, transform.position.z);
            horizontalSpeed = -horizontalSpeed;
        }
        else if (transform.position.x < leftBorder)
        {
            //Move slighly to the inside, otherwise it may stuck in one end
            transform.position = new Vector3(leftBorder + 0.1f, transform.position.y, transform.position.z);
            horizontalSpeed = -horizontalSpeed;
        }

    }
}

