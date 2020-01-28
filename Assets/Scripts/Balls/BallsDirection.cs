using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsDirection : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField] float speed;
    [SerializeField] bool isGoingLeft;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (isGoingLeft)
        {
            direction = new Vector2( -speed , 0);
        }
        
        else if (!isGoingLeft)
        {
            direction = new Vector2( speed , 0);
        }
        
        body.AddForce(direction);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            if (isGoingLeft)
            {
                isGoingLeft = false;
            }
            
            else if (!isGoingLeft)
            {
                isGoingLeft = true;
            }
        }
    }
}

    