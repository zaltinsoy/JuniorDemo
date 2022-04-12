using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed = 5f;
    private Rigidbody rb;
    private float newXPosition;
    private float playerXSpeed = 2f;
    private float xMovement;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            newXPosition = transform.position.x + Input.GetAxisRaw("Horizontal") * playerXSpeed;
        }
    }
    private void FixedUpdate()
    {
        xMovement = transform.position.x + playerXSpeed * Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
        rb.MovePosition(new Vector3(xMovement,0, transform.position.z+ playerSpeed*Time.fixedDeltaTime));

            //collider'larla da düzgün çalýþýyor, içinden geçmiyor.
            //restart the game eklenecek
            //sýnýrýn dýþýna çýkarsa nanay eklenecek

    }
}
