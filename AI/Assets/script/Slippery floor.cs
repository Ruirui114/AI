using UnityEngine;

public class Slipperyfloor : MonoBehaviour
{
    [Tooltip("滑りの強さ（1に近いほどツルツル）")]
    [Range(0.8f, 0.99f)]
    public float inertia = 1f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.rigidbody;
            if (rb == null) return;

            // プレイヤー入力を検出（左右移動）
            float inputX = Input.GetAxisRaw("Horizontal");

            // 入力がない時だけ慣性を残す
            if (Mathf.Abs(inputX) < 0.1f)
            {
                // 徐々に減速させる（滑る感覚）
                rb.linearVelocity = new Vector2(rb.linearVelocity.x * inertia, rb.linearVelocity.y);
            }
        }
    }
}
