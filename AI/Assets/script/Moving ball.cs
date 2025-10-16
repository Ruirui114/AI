using UnityEngine;

public class Movingball : MonoBehaviour
{
    [Header("��������")]
    public float speed = 2f;

    [Header("�����͈́i�����ʒu����̋����j")]
    public float moveRange = 2f;

    [Header("�v���C���[�̃^�O��")]
    public string playerTag = "Player";

    [Header("�v���C���[�̃��X�|�[���ʒu")]
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
        // Shift�L�[�œ����ON/OFF�؂�ւ�
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isMoving = !isMoving;
        }

        // ���쒆�Ȃ�ړ�
        if (isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        // �㉺�ړ�����
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
            // Player�X�N���v�g���擾
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                // Player��Respawn���\�b�h���Ăяo��
                player.Respawn();
            }
        }
    }
}
