using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;
    private int direction = 1; // �E�����Ȃ�1�A�������Ȃ�-1

    void Start()
    {
        Destroy(gameObject, lifeTime); // ��莞�Ԍ�Ɏ���
    }

    void Update()
    {
        // �܂�������΂��idirection�ō��E���]�j
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
    }

    // �G������Ă΂�郁�\�b�h
    public void SetDirection(bool facingRight)
    {
        direction = facingRight ? 1 : -1;

        // �������Ȃ猩���ڂ����]
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
            // �v���C���[�ɓ��������烊�X�|�[��
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Respawn();
            }

            Destroy(gameObject); // �e������
        }
        else if (!collision.isTrigger)
        {
            // �ǂȂǂɓ���������e������
            Destroy(gameObject);
        }
    }
}
