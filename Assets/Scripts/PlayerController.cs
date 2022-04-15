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

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            newXPosition = transform.position.x + Input.GetAxisRaw("Horizontal") * playerXSpeed;
        }

        if (transform.position.z >= finishLine)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            newRotation = new Vector3(0, 0, 0);
            //newTransform.eulerAngles= new Vector3(0, 0, 0);
            cam.transform.eulerAngles = newRotation;

            // Quaternion.RotateTowards(cam.transform.rotation,newTransform.rotation, 30f);

        }

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

       // newXPosition = transform.position.x + moveFactorX * playerXSpeed;



    }
    private void FixedUpdate()
    {
        //xMovement = transform.position.x + playerXSpeed * Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
       
        xMovement = transform.position.x + playerXSpeed * moveFactorX * Time.fixedDeltaTime;

        rb.MovePosition(new Vector3(xMovement, 0, transform.position.z + playerSpeed * Time.fixedDeltaTime));
        //restart the game eklenecek
        //sýnýrýn dýþýna ne olacaðýna karar verilecek


    }

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
        if (other.CompareTag("RotStick"))
        {
            rb.AddForce(lastNormal * 800f);
            //en son dokunmanýn yönünde ekstra kuvvet oluþturuyor
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "RotStick")
        {
            numberContact = other.contacts.Length;
            lastNormal = other.contacts[0].normal;
            Debug.Log(lastNormal);
        }
    }



}

