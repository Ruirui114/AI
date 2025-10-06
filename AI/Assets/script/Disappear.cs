using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("�o���u���b�N��Prefab")]
    public GameObject blockPrefab; // �o�������u���b�N�iPrefab�j
    [Header("�o���ʒu")]
    public Transform spawnPoint;   // �o���ʒu
    [Header("�u���b�N�̕\�����ԁi�b�j")]
    public float duration = 3f;    // �o�����Ă��鎞��

    private GameObject spawnedBlock;
    private bool isActive = false;

    void Update()
    {
        // Shift�L�[�ŏo���iInput System �s�g�p�j
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (!isActive)
            {
                StartCoroutine(SpawnTempBlock());
            }
        }
    }

    private System.Collections.IEnumerator SpawnTempBlock()
    {
        isActive = true;

        // �u���b�N�𐶐�
        spawnedBlock = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity);

        // duration �b�҂�
        yield return new WaitForSeconds(duration);

        // �u���b�N������
        Destroy(spawnedBlock);
        isActive = false;
    }
}
