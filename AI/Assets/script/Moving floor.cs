using UnityEngine;

public class Movingfloor : MonoBehaviour
{
    [Header("�ړ����x")]
    public float speed = 2f;

    [Header("�ړ������i�����ʒu����̕Г������j")]
    public float moveRange = 3f;

    [Header("����؂�ւ��L�[")]
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
        // Shift�L�[�œ����ON/OFF��؂�ւ�
        if (Input.GetKeyDown(toggleKey))
        {
            isMoving = !isMoving;
        }

        // �����Ă���Ƃ�����Move()�����s
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
