using UnityEngine;

public class UPFloorSpawn : MonoBehaviour
{
    [Header("��ɓ������̃v���n�u")]
    public GameObject platformPrefab;

    [Header("�����Ԋu�i�b�j")]
    public float spawnInterval = 5f;

    [Header("�㏸�X�s�[�h�i�P��/�b�j")]
    public float riseSpeed = 1f;

    [Header("����������܂ł̎��ԁi�b�j")]
    public float lifeTime = 20f;

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

        // �㏸����X�N���v�g��ݒ�
        MovingUPDOWN mover = platform.GetComponent<MovingUPDOWN>();

        // �v���n�u�ɃX�N���v�g���Ȃ��ꍇ�A�����Œǉ�
        if (mover == null)
        {
            mover = platform.AddComponent<MovingUPDOWN>();
        }

        // �ړ��X�s�[�h�Ǝ�����ݒ�
        mover.Setup(riseSpeed, lifeTime);
    }
}
