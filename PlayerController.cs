using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float moveSpeed =1f ;
    bool facingRight = true;
    Animator playerAnimator;
    public float jumpSpeed = 1f, jumpFrequency= 1f, nextJumpTime;
    bool isGrounded = true;
    public Transform GroundCheckPosition;
    public float GroundCheckRadius;
    public LayerMask GroundCheckLayer;

   
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight)
        {
            Flipface();
        }

        else if (playerRB.velocity.x > 0 && !facingRight) 
        {
            Flipface();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }

        

    }

    private void FixedUpdate()
    {

    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void Flipface()

    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void jump()
    {
        playerRB.AddForce(new Vector2 (0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckPosition.position, GroundCheckRadius, GroundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}


