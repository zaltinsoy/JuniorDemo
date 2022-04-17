using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    private Rigidbody rb;
    private float playerXSpeed = 5f;
    private float xMovement;
    private float RotationSpeed = 5000f;

   // private int numberContact;
    private Vector3 lastNormal;
    private float lastFrameFingerPositionX;
    private float moveFactorX;

    public GameObject gamePlatform;
    public float leftBorder;
    public float rightBorder;

    private Quaternion deltaRotation;

    private float finishLine = 150f;
    public GameObject wall;
    public GameObject cam;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightBorder = gamePlatform.transform.localScale.z / 4;
        leftBorder = -rightBorder;
    }

 
    // Physics related movement calculations:
    private void FixedUpdate()
    {
        xMovement = transform.position.x + playerXSpeed * moveFactorX * Time.fixedDeltaTime;

        Vector3 movementDirection = new Vector3(xMovement, 0, transform.position.z + playerSpeed * Time.fixedDeltaTime);

        //rb.MovePosition(new Vector3(xMovement, 0, transform.position.z + playerSpeed * Time.fixedDeltaTime));

        rb.MovePosition(movementDirection);

        Vector3 rotateDirection = movementDirection.normalized;

        if(movementDirection!=Vector3.zero)
        {
         //   transform.forward = rotateDirection; //çalýþýyor valla bu ama daha hýzlýsý lazým bize 
            Quaternion toRotation = Quaternion.LookRotation(movementDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.fixedDeltaTime);
        }
        /*
        if (moveFactorX != 0)
        {
            Debug.Log("dönme hareketi");

            deltaRotation = Quaternion.Euler(0, 10 * playerXSpeed * moveFactorX * Time.fixedDeltaTime, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);


        }
        */
        else if (moveFactorX == 0)
        {
            Debug.Log(moveFactorX + "niye çalýþmýyor");

            
            //Quaternion deltaForward = Quaternion.Euler(0, -(transform.localEulerAngles.y), 0);
           
            //rb.MoveRotation(rb.rotation * deltaForward);
            //Quaternion backRotate= Quaternion.Euler(0, 10 * playerXSpeed * -moveFactorX * Time.fixedDeltaTime, 0);
            
            //rb.MoveRotation(rb.rotation * deltaForward);

        }



        // Swerve type movement input
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }


    }

    void Update()
    {
        // Moves and rotate the camera towards the wall at the end
        if (transform.position.z >= finishLine)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cam.transform.position = new Vector3(0, 8, finishLine - 7);
            cam.transform.LookAt(wall.transform);

        }

        // Restrict the player movement to the gamefield
        if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < leftBorder)
        {
            transform.position = new Vector3(leftBorder + 0.1f, transform.position.y, transform.position.z);
        }

        else if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }


    }
    // Reset the player position in case of collision with Reseter type objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reseter"))
        {
            transform.position = new Vector3(0, 0, 0);
            transform.localEulerAngles = new Vector3(0, 0);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        // Rotstick apply extra force on the player in the direction of last contact normal
        if (other.CompareTag("RotStick"))
        {
            rb.AddForce(lastNormal * 800f);
        }
    }
    //Check the last contact normal with player and rotstick
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "RotStick")
        {
          //  numberContact = other.contacts.Length;
            lastNormal = other.contacts[0].normal;
        }
    }



}

