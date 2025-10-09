using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("�o������������肷��I�u�W�F�N�g")]
    public GameObject[] targetObjects;

    void Update()
    {
        // ��Shift�������ꂽ�u�ԂɃg�O��
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleObjects();
        }
    }

    void ToggleObjects()
    {
        if (targetObjects == null || targetObjects.Length == 0)
            return;

        // �ŏ��̃I�u�W�F�N�g�̏�Ԃ���ɔ��]
        bool newState = !targetObjects[0].activeSelf;

        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(newState);
        }
    }
}
