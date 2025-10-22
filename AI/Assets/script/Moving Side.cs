using UnityEngine;

public class MovingSide : MonoBehaviour
{
    [Header("���E�ɓ��������i�U�ꕝ�j")]
    public float moveRange = 2f;

    [Header("�����X�s�[�h")]
    public float moveSpeed = 2f;

    [Header("�������~�߂�L�[")]
    public KeyCode toggleKey = KeyCode.LeftShift;

    private bool isMoving = true;   // ���쒆���ǂ���
    private Vector3 startPos;       // �����ʒu

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

        // ���쒆�̂ݍ��E�Ɉړ�
        if (isMoving)
        {
            float newX = startPos.x + Mathf.Sin(Time.time * moveSpeed) * moveRange;
            transform.position = new Vector3(newX, startPos.y, startPos.z);
        }
    }
}
