using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsLife : MonoBehaviour
{
    
    Rigidbody2D body;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            GetComponentInParent<BallsCounter>().ballsCounter();
        }
    }
}
