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

    [SerializeField] float jumpVelocity = 6;
    [SerializeField] float raycastJumpLength = 1f;

    [SerializeField] float timeStopJump = 0.1f;
    float timerStopJump = 0;
    [SerializeField] float jumpFallingModifier = 1;
    bool canJump = true;

    [SerializeField]
    float speed = 4;
    [SerializeField]
    float maxSpeed = 10;

    //[SerializeField] List<SO_Clip> jumpClips_;

    ShooterController shooterController_;

    PlayerHealth playerHealth;

    Animator animator_;

    SpriteRenderer spriteRenderer_;
    bool isLookingRight = true;

    //AudioManager audioManager_;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer_ = GetComponentInChildren<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
        animator_ = GetComponentInChildren<Animator>();
        shooterController_ = GetComponentInChildren<ShooterController>();



        //audioManager_ = FindObjectOfType<AudioManager>();

        //gunController_.SetAudioManager(audioManager_);
    }

    void FixedUpdate()
    {
        body.velocity = direction;

        //If player is falling => Multiply falling speed
        if (body.velocity.y < 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * jumpFallingModifier);
        }
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
    }

    void Update()
    {
        UpdateMovement();

        //UpdateAnimation();
    }

    void UpdateMovement()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        CheckJump();
    }

    /*void UpdateAnimation()
    {
        animator_.SetFloat("speed", Mathf.Abs(body.velocity.x));

        if (body.velocity.x < 0.1f && isLookingRight)
        {
            spriteRenderer_.flipX = true;
            isLookingRight = false;
        }
        else if (body.velocity.x > 0.1f && !isLookingRight)
        {
            spriteRenderer_.flipX = false;
            isLookingRight = true;
        }

        animator_.SetBool("isFalling", Mathf.Abs(body.velocity.y) > 0.1f);
    }*/

    void CheckJump()
    {
        timerStopJump -= Time.deltaTime;

        if (timerStopJump > 0)
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastJumpLength, 1 << LayerMask.NameToLayer("Platform"));
        canJump = hit.rigidbody != null;

        if (!(Input.GetAxis("Jump") > 0.1f) || !canJump) return;


        //audioManager_.PlayWithRandomPitch(jumpClips_[Random.Range(0, jumpClips_.Count)]);
        //animator_.SetTrigger("jump");
        direction.y += jumpVelocity;
        canJump = false;
        timerStopJump = timeStopJump;
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
