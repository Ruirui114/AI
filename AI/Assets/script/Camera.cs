using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // �v���C���[
    public float smoothSpeed = 5f; // �J�����Ǐ]�̂Ȃ߂炩��
    public Vector3 offset = new Vector3(0, 1, -10); // �J�����ʒu�̃I�t�Z�b�g

    void LateUpdate()
    {
        if (target == null) return;

        // �������Ǐ]�i�c�͌Œ�j
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, 0) + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothed;
    }
}
