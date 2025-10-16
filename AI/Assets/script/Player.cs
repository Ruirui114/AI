using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool canJump = true;
    [Header("地面チェック（Tag使用）")]
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public string groundTag = "Ground";
    public string iceTag = "Ice";

    [Header("壁チェック（Layer使用）")]
    public Transform wallCheck;
    public float wallCheckDistance = 0.2f;
    public LayerMask wallLayer;

    public Vector2 respawnPoint;
    public float fallThreshold = -10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isFacingRight = true;
    private bool isOnIce = false;

    private float iceFriction = 0.96f; // 慣性の残りやすさ（0.9〜0.99）

    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (moveInput > 0 && !isFacingRight) Flip();
        else if (moveInput < 0 && isFacingRight) Flip();

        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    // ⭐ ここをFixedUpdateに変更！
    void FixedUpdate()
    {
        CheckGround();
        CheckWall();

        if (!isTouchingWall)
        {
            if (isOnIce)
            {
                // 氷の床：入力がない時にゆっくり減速
                if (Mathf.Abs(moveInput) > 0.1f)
                {
                    rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
                }
                else
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x * iceFriction, rb.linearVelocity.y);
                }
            }
            else
            {
                // 通常地面：すぐ止まる
                rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius);
        isGrounded = false;
        isOnIce = false;

        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag(groundTag))
            {
                isGrounded = true;
                break;
            }
            else if (col.CompareTag(iceTag))
            {
                isGrounded = true;
                isOnIce = true;
                break;
            }
        }
    }

    private void CheckWall()
    {
        Vector2 checkDir = isFacingRight ? Vector2.right : Vector2.left;
        Vector2 wallCheckPos = wallCheck.position + Vector3.up * 0.1f;

        RaycastHit2D hit = Physics2D.BoxCast(
            wallCheckPos,
            new Vector2(0.3f, 0.8f),
            0f,
            checkDir,
            wallCheckDistance,
            wallLayer
        );

        isTouchingWall = (hit.collider != null);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = respawnPoint;
    }
}
