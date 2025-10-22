using UnityEngine;

public class MovingSide : MonoBehaviour
{
    [Header("左右に動く距離（振れ幅）")]
    public float moveRange = 2f;

    [Header("動くスピード")]
    public float moveSpeed = 2f;

    [Header("動きを止めるキー")]
    public KeyCode toggleKey = KeyCode.LeftShift;

    private bool isMoving = true;   // 動作中かどうか
    private Vector3 startPos;       // 初期位置

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Shiftキーで動作のON/OFFを切り替え
        if (Input.GetKeyDown(toggleKey))
        {
            isMoving = !isMoving;
        }

        // 動作中のみ左右に移動
        if (isMoving)
        {
            float newX = startPos.x + Mathf.Sin(Time.time * moveSpeed) * moveRange;
            transform.position = new Vector3(newX, startPos.y, startPos.z);
        }
    }
}
