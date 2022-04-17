using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour



{
    private Rigidbody rb;
    public float playerSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(new Vector3(0, 0, transform.position.z + playerSpeed * Time.fixedDeltaTime));

    }
}
