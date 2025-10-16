using UnityEngine;

public class Movingball : MonoBehaviour
{
    [Header("動く速さ")]
    public float speed = 2f;

    [Header("動く範囲（初期位置からの距離）")]
    public float moveRange = 2f;

    [Header("プレイヤーのタグ名")]
    public string playerTag = "Player";

    [Header("プレイヤーのリスポーン位置")]
    public Transform respawnPoint;

    private Vector3 startPos;
    private bool movingUp = true;
    private bool isMoving = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Shiftキーで動作のON/OFF切り替え
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isMoving = !isMoving;
        }

        // 動作中なら移動
        if (isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        // 上下移動処理
        float moveStep = speed * Time.deltaTime;
        if (movingUp)
        {
            transform.position += Vector3.up * moveStep;
            if (transform.position.y >= startPos.y + moveRange)
                movingUp = false;
        }
        else
        {
            transform.position -= Vector3.up * moveStep;
            if (transform.position.y <= startPos.y - moveRange)
                movingUp = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            // Playerスクリプトを取得
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                // PlayerのRespawnメソッドを呼び出す
                player.Respawn();
            }
        }
    }
}
