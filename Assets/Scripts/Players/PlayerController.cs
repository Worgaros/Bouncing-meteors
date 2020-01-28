using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Movements
    Rigidbody2D body;

    Vector2 direction;

    [SerializeField] float jumpVelocity = 1f;
    [SerializeField] float raycastJumpLength = 1f;

    [SerializeField] float timeStopJump = 0.1f;
    
    bool canJump = true;

    [SerializeField]
    float speed = 4;
    [SerializeField]
    float maxSpeed = 10;

    ShooterController shooterController_;
    

    Animator animator_;

    SpriteRenderer spriteRenderer_;
    bool isLookingRight = true;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer_ = GetComponentInChildren<SpriteRenderer>();
        animator_ = GetComponentInChildren<Animator>();
        shooterController_ = GetComponentInChildren<ShooterController>();
    }

    void FixedUpdate()
    {
        body.velocity = direction;

        
        if (body.velocity.y < 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y);
        }
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
    }

    void Update()
    {
        UpdateMovement();
        
    }

    void UpdateMovement()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
    }

    

    
    public ShooterController GetGun()
    {
        return shooterController_;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.down * raycastJumpLength);

        Gizmos.DrawWireCube((Vector2)transform.position + Vector2.down * 0.5f, new Vector2(1f, 0.2f));
    }
}
