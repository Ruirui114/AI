using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [Header("落ちる床のプレハブ")]
    public GameObject platformPrefab;

    [Header("生成間隔（秒）")]
    public float spawnInterval = 5f;

    [Header("落ちるスピード（単位/秒）")]
    public float fallSpeed = 1f;

    [Header("床が消えるまでの時間（秒）")]
    public float lifeTime = 20f; // ← ここを20秒に設定

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

        // 落下制御スクリプトを設定
        Fallingfloor mover = platform.GetComponent<Fallingfloor>();

        // プレハブにスクリプトがない場合、自動で追加
        if (mover == null)
        {
            mover = platform.AddComponent<Fallingfloor>();
        }

        // 移動スピードと寿命を設定
        mover.Setup(fallSpeed, lifeTime);
    }
}
