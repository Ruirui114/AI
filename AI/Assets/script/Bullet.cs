using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;
    private int direction = 1; // 右向きなら1、左向きなら-1

    void Start()
    {
        Destroy(gameObject, lifeTime); // 一定時間後に自壊
    }

    void Update()
    {
        // まっすぐ飛ばす（directionで左右反転）
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
    }

    // 敵側から呼ばれるメソッド
    public void SetDirection(bool facingRight)
    {
        direction = facingRight ? 1 : -1;

        // 左向きなら見た目も反転
        if (!facingRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // プレイヤーに当たったらリスポーン
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Respawn();
            }

            Destroy(gameObject); // 弾も消す
        }
        else if (!collision.isTrigger)
        {
            // 壁などに当たったら弾を消す
            Destroy(gameObject);
        }
    }
}
