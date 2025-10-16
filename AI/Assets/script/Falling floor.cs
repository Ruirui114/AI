using UnityEngine;

public class Fallingfloor : MonoBehaviour
{
    [Header("�����鏰�̃v���n�u")]
    public GameObject platformPrefab;

    [Header("�����Ԋu�i�b�j")]
    public float spawnInterval = 2f;

    [Header("������X�s�[�h�i�P��/�b�j")]
    public float fallSpeed = 2f;

    [Header("����������܂ł̎��ԁi�b�j")]
    public float lifeTime = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // ���Ԋu�ŏ��𐶐�
        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        // �X�|�i�[�̈ʒu�ɏ��𐶐�
        GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);

        // �����������𐧌䂷�邽�߂̃X�N���v�g��ǉ�
        platform.AddComponent<FallingPlatformMove>().Setup(fallSpeed, lifeTime);
    }
}
public class FallingPlatformMove : MonoBehaviour
{
    private float fallSpeed;
    private float lifeTime;

    // �p�����[�^���Z�b�g����֐�
    public void Setup(float speed, float time)
    {
        fallSpeed = speed;
        lifeTime = time;
    }

    void Start()
    {
        // ��莞�Ԍ�Ɏ����폜
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move�ŉ������Ɉړ�
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}