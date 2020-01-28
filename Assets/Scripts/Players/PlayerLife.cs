using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D body;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("balls"))
        //{
            Destroy(gameObject);
        //}
    }
}
