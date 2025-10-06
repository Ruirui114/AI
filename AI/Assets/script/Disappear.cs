using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("出すブロックのPrefab")]
    public GameObject blockPrefab; // 出したいブロック（Prefab）
    [Header("出す位置")]
    public Transform spawnPoint;   // 出現位置
    [Header("ブロックの表示時間（秒）")]
    public float duration = 3f;    // 出現している時間

    private GameObject spawnedBlock;
    private bool isActive = false;

    void Update()
    {
        // Shiftキーで出現（Input System 不使用）
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

        // ブロックを生成
        spawnedBlock = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity);

        // duration 秒待つ
        yield return new WaitForSeconds(duration);

        // ブロックを消す
        Destroy(spawnedBlock);
        isActive = false;
    }
}
