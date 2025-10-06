using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("地面チェック（Tag使用）")]
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public string groundTag = "Ground"; // 地面のTag名

    [Header("壁チェック（Layer使用）")]
    public Transform wallCheck;
    public float wallCheckDistance = 0.2f;
    public LayerMask wallLayer; // 壁はLayerで判定

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
        CheckWall();

        float move = Input.GetAxis("Horizontal");

        // 壁に当たってなければ動ける
        if (!isTouchingWall)
        {
            rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            // 壁に当たってたら横移動を止めて落下
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // 地面にいるときだけジャンプ可能
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 向き反転
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }

    private void CheckGround()
    {
        // 足元円の中にあるColliderを全部取得
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius);
        isGrounded = false;

        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag(groundTag))
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void CheckWall()
    {
        Vector2 checkDir = isFacingRight ? Vector2.right : Vector2.left;
        Vector2 wallCheckPos = wallCheck.position + Vector3.up * 0.1f; // 少し上にずらす（地面との誤検出防止）

        // BoxCastで範囲を広げた判定（幅0.3, 高さ0.8）
        RaycastHit2D hit = Physics2D.BoxCast(
            wallCheckPos,                   // 中心
            new Vector2(0.3f, 0.8f),        // サイズ（←ここで当たり範囲を調整）
            0f,                             // 回転角度
            checkDir,                       // 方向
            wallCheckDistance,              // 飛ばす距離
            wallLayer                       // 対象Layer
        );

        isTouchingWall = (hit.collider != null);

        //isTouchingWall = Physics2D.Raycast(wallCheckPos, checkDir, wallCheckDistance, wallLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }

        if (wallCheck != null)
        {
            Gizmos.color = Color.cyan;
            Vector2 dir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            Vector3 startPos = wallCheck.position + Vector3.up * 0.1f;
            Gizmos.DrawLine(startPos, startPos + (Vector3)(dir * wallCheckDistance));
        }
    }
}
