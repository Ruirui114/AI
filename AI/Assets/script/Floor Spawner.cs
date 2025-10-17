using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Header("�����鏰�̃v���n�u")]
    public GameObject platformPrefab;

    [Header("�����Ԋu�i�b�j")]
    public float spawnInterval = 5f;

    [Header("������X�s�[�h�i�P��/�b�j")]
    public float fallSpeed = 1f;

    [Header("����������܂ł̎��ԁi�b�j")]
    public float lifeTime = 20f; // �� ������20�b�ɐݒ�

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

        // ��������X�N���v�g��ݒ�
        Fallingfloor mover = platform.GetComponent<Fallingfloor>();

        // �v���n�u�ɃX�N���v�g���Ȃ��ꍇ�A�����Œǉ�
        if (mover == null)
        {
            mover = platform.AddComponent<Fallingfloor>();
        }

        // �ړ��X�s�[�h�Ǝ�����ݒ�
        mover.Setup(fallSpeed, lifeTime);
    }
}
