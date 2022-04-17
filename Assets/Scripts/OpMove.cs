using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OpMove : MonoBehaviour
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
        agent.SetDestination(new Vector3 (0, 0, 150));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reseter"))
        {
            //transform.position = new Vector3(0, 0, 0);
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

    }
    //son anda ittirmesi daha g�zel oldu �nce d�n�yor ��k��ta f�rlat�yor
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