using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float speed = 10f;
    [SerializeField]private float jumpStrength = 5f;
    [SerializeField]private float cyoteTime = 0.15f;
    [SerializeField]private float jumpBufferTime = 0.5f;
    [SerializeField]private float dashColdawn = 2f;
    [SerializeField]private float dashDistance = 50f;
    [SerializeField]private Animator anime;
    private bool isCrouching;
    private int facingDir = 1;
    private float jumpBufferCounter;
    private float cyoteTimeCounter;
    private float dashColdawnCounter;
    private bool isGrounded;
    private bool isFalling;
    private float timeInAir;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        anime.SetBool("IsFalling", true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (isGrounded)
        {
            cyoteTimeCounter = cyoteTime;
        }
        else
        {
            cyoteTimeCounter -= Time.deltaTime;
        }
        if ((Input.GetButtonDown("Jump") || jumpBufferCounter > 0f) && (isGrounded || cyoteTimeCounter > 0f))
        {
            Jump();
            cyoteTimeCounter = 0f;
        }
        
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(moveX * speed, _rb.velocity.y);
        float Horizontal =Input.GetAxis("Horizontal");
        if (Horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        if (Horizontal > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        anime.SetFloat("Horizontal", Math.Abs(Input.GetAxis("Horizontal")));
        anime.SetFloat("Vertical", _rb.velocity.y);
        Crouch();
        Dash();
  
    }
    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }
    void Flip()
    {
        facingDir *= -1;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void Crouch()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if (isCrouching) return; 
            isCrouching = true;
            anime.SetBool("IsCrouched",true);
            speed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (!isCrouching) return;
            isCrouching = false;
            anime.SetBool("IsCrouched", false);
            speed *= 2;
        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashColdawnCounter <= 0)
        {
            anime.SetBool("IsDashing", true);
            _rb.velocity = new Vector2(dashDistance * facingDir, _rb.velocity.y);
            dashColdawnCounter = dashColdawn;
        }
        dashColdawnCounter -= Time.deltaTime;
    }
    void SDash()
    {
        anime.SetBool("IsDashing", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
        isGrounded = true;
        isFalling = false;
        timeInAir = 0f;
        anime.SetBool("IsFalling", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            timeInAir += Time.deltaTime;
            if (timeInAir > 2.5f)
            {
                isFalling = true;
                anime.SetBool("IsFalling", true);
            }
        }
    }
}