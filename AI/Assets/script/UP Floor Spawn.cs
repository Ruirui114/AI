using UnityEngine;

public class UPFloorSpawn : MonoBehaviour
{
    [Header("上に動く床のプレハブ")]
    public GameObject platformPrefab;

    [Header("生成間隔（秒）")]
    public float spawnInterval = 5f;

    [Header("上昇スピード（単位/秒）")]
    public float riseSpeed = 1f;

    [Header("床が消えるまでの時間（秒）")]
    public float lifeTime = 20f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // 一定間隔で床を生成
        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        // スポナーの位置に床を生成
        GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);

        // 上昇制御スクリプトを設定
        MovingUPDOWN mover = platform.GetComponent<MovingUPDOWN>();

        // プレハブにスクリプトがない場合、自動で追加
        if (mover == null)
        {
            mover = platform.AddComponent<MovingUPDOWN>();
        }

        // 移動スピードと寿命を設定
        mover.Setup(riseSpeed, lifeTime);
    }
}
