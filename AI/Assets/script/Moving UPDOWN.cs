using UnityEngine;

public class MovingUPDOWN : MonoBehaviour
{
    private float riseSpeed = 2f;
    private float lifeTime = 5f;
    private Rigidbody2D rb;

    public string playerTag = "Player";

    public void Setup(float speed, float time)
    {
        riseSpeed = speed;
        lifeTime = time;
        Destroy(gameObject, lifeTime);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void FixedUpdate()
    {
        // 上方向に移動
        rb.MovePosition(rb.position + Vector2.up * riseSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag)) return;

        ContactPoint2D contact = collision.contacts[0];
        Vector2 normal = contact.normal;

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (playerRb == null) return;

        if (normal.y > 0.5f)
        {
            // ✅ 上から乗った時 → 物理反発を完全に無効化
            collision.transform.SetParent(transform);
            playerRb.linearVelocity = Vector2.zero;

            // ✅ 跳ねないように一時的にKinematicに変更
            playerRb.bodyType = RigidbodyType2D.Kinematic;
        }
        else if (normal.y < -0.5f)
        {
            // 下から当たった時 → 押し上げる（任意）
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 8f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag)) return;

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (playerRb != null && playerRb.bodyType == RigidbodyType2D.Kinematic)
        {
            // ✅ プレイヤーを床に固定して滑らかに追従
            playerRb.transform.position = new Vector3(
                playerRb.transform.position.x,
                transform.position.y + 0.5f, // プレイヤーが床の上にいるように少しオフセット
                playerRb.transform.position.z
            );
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag)) return;

        collision.transform.SetParent(null);

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            // ✅ 床から離れたら物理挙動を戻す
            playerRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
