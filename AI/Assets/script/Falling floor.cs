using UnityEngine;

public class Fallingfloor : MonoBehaviour
{
    private float fallSpeed = 2f;
    private float lifeTime = 5f;
    private Rigidbody2D rb;

    public string playerTag = "Player";

    public void Setup(float speed, float time)
    {
        fallSpeed = speed;
        lifeTime = time;

        // 指定時間後に消滅
        Destroy(gameObject, lifeTime);
    }

    void Start()
    {
        // Rigidbodyを確保・設定
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Rigidbodyで下方向に滑らかに移動
        Vector2 newPosition = rb.position + Vector2.down * fallSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag)) return;

        ContactPoint2D contact = collision.contacts[0];
        Vector2 normal = contact.normal;

        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (normal.y > 0.5f)
        {
            // 上から乗った時 → 親子化してガクガク防止
            collision.transform.SetParent(transform);
        }
        else
        {
            // 横・下から当たった時 → プレイヤーを下に落とす
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, -8f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag)) return;

        if (collision.transform.parent == transform)
        {
            collision.transform.SetParent(null);
        }
    }
}