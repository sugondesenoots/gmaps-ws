using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = rb.GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse); //Applies force once
     }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

