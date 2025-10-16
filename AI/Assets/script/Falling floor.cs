using UnityEngine;

public class Fallingfloor : MonoBehaviour
{
    [Header("落ちる床のプレハブ")]
    public GameObject platformPrefab;

    [Header("生成間隔（秒）")]
    public float spawnInterval = 2f;

    [Header("落ちるスピード（単位/秒）")]
    public float fallSpeed = 2f;

    [Header("床が消えるまでの時間（秒）")]
    public float lifeTime = 5f;

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

        // 生成した床を制御するためのスクリプトを追加
        platform.AddComponent<FallingPlatformMove>().Setup(fallSpeed, lifeTime);
    }
}
public class FallingPlatformMove : MonoBehaviour
{
    private float fallSpeed;
    private float lifeTime;

    // パラメータをセットする関数
    public void Setup(float speed, float time)
    {
        fallSpeed = speed;
        lifeTime = time;
    }

    void Start()
    {
        // 一定時間後に自動削除
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Moveで下方向に移動
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}