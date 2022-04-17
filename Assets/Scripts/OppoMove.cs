using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OppoMove : MonoBehaviour
{

    public NavMeshAgent agent;
    private Rigidbody rb;

    private int numberContact;
    private Vector3 lastNormal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        agent.SetDestination(new Vector3(0, 0, 149));
        if (transform.position.z > 147)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Send opponents to the start location
        if (other.CompareTag("Reseter"))
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
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
            numberContact = other.contacts.Length;
            lastNormal = other.contacts[0].normal;
        }
    }

}
