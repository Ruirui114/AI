using UnityEngine;

public class Movingfloor : MonoBehaviour
{
    [Header("移動速度")]
    public float speed = 2f;

    [Header("移動距離（初期位置からの片道距離）")]
    public float moveRange = 3f;

    [Header("動作切り替えキー")]
    public KeyCode toggleKey = KeyCode.LeftShift;

    private Vector3 startPos;
    private bool movingRight = true;
    private bool isMoving = false; 

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

        // 動いているときだけMove()を実行
        if (isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        float moveStep = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.position += Vector3.right * moveStep;
            if (transform.position.x >= startPos.x + moveRange)
                movingRight = false;
        }
        else
        {
            transform.position -= Vector3.right * moveStep;
            if (transform.position.x <= startPos.x - moveRange)
                movingRight = true;
        }
    }
}
