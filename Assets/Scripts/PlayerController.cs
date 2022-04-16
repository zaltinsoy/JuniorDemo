using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 1f;
    private Rigidbody rb;
    private float newXPosition;
    private float playerXSpeed = 5f;
    private float xMovement;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private int numberContact;
    private Vector3 lastNormal;
    private float finishLine = 50f;
    public GameObject cam;
    private Transform rotTrans;
    private Vector3 newRotation;
    private Transform newTransform;
    private float lastFrameFingerPositionX;
    private float moveFactorX;

    public GameObject gamePlatform;
    public float leftBorder;
    public float rightBorder;

    public GameObject wall;
    
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightBorder = gamePlatform.transform.localScale.z / 4;
        leftBorder = -rightBorder;

    }

    // Update is called once per frame
    void Update()
    {
        // Old movement system
        //if (Input.GetButtonDown("Horizontal"))
        //{
        //    newXPosition = transform.position.x + Input.GetAxisRaw("Horizontal") * playerXSpeed;
        //}

        // When player reaches the finish line camera move towards the wall
        if (transform.position.z >= finishLine)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            newRotation = new Vector3(0, 0, 0);
            //newTransform.eulerAngles= new Vector3(0, 0, 0);

            //cam.transform.eulerAngles = newRotation;

            // Quaternion.RotateTowards(cam.transform.rotation,newTransform.rotation, 30f);
            cam.transform.position = new Vector3(0, 6, 43);
            cam.transform.LookAt(wall.transform);

        }

        // Restrict the player movement to the gamefield
        if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < leftBorder)
        {
            transform.position = new Vector3(leftBorder+0.1f, transform.position.y, transform.position.z);
        }

        else if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }


    }
    // Physics related movement calculations:
    private void FixedUpdate()
    {
        //Old movement type:
        //xMovement = transform.position.x + playerXSpeed * Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
       
        xMovement = transform.position.x + playerXSpeed * moveFactorX * Time.fixedDeltaTime;

        rb.MovePosition(new Vector3(xMovement, 0, transform.position.z + playerSpeed * Time.fixedDeltaTime));
        
        //restart the game eklenecek
        
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
    // Reset the player position incase of collision with Reseter type objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reseter"))
        {
            transform.position = new Vector3(0, 0, 0);
        }

    }
    //son anda ittirmesi daha güzel oldu önce dönüyor çýkýþta fýrlatýyor
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
            numberContact = other.contacts.Length;
            lastNormal = other.contacts[0].normal;
        }
    }



}

