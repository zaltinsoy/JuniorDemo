using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    private float rotationSpeed= 10f;
    private float horizontalSpeed = 5f;

    public GameObject gamePlatform;
    public float leftBorder;
    public float rightBorder;

    // Start is called before the first frame update
    void Start()
    {
        rightBorder = gamePlatform.transform.localScale.z / 4;
        leftBorder = -rightBorder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
        transform.position = transform.position + new Vector3(horizontalSpeed * Time.fixedDeltaTime, 0, 0);
        if (transform.position.x > rightBorder)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        else if (transform.position.x <leftBorder)
        {
            horizontalSpeed = -horizontalSpeed;
        }

    }
}

