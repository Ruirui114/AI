using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // プレイヤー
    public float smoothSpeed = 5f; // カメラ追従のなめらかさ
    public Vector3 offset = new Vector3(0, 1, -10); // カメラ位置のオフセット

    void LateUpdate()
    {
        if (target == null) return;

        // 横だけ追従（縦は固定）
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, 0) + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothed;
    }
}
