using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float speed = 10f;
    [SerializeField]private float jumpStrength = 5f;
    [SerializeField]private float cyoteTime = 0.15f;
    [SerializeField]private float jumpBufferTime = 0.5f;
    private float jumpBufferCounter;

    private float cyoteTimeCounter;
    private bool isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
    }
    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}