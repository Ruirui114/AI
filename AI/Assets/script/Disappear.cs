using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("�ʏ�ON/OFF����I�u�W�F�N�g�Q")]
    public GameObject[] normalObjects;

    [Header("�t�^�C�~���O�Ő؂�ւ���I�u�W�F�N�g�Q")]
    public GameObject[] inverseObjects;

    [Header("�؂�ւ��L�[")]
    public KeyCode toggleKey = KeyCode.LeftShift;

    private bool isToggled = false; // ���݂̏�ԋL�^�ifalse = �ʏ�ON�j

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleAll();
        }
    }

    void ToggleAll()
    {
        isToggled = !isToggled;

        // �ʏ�g�iON��OFF��ON�j
        foreach (GameObject obj in normalObjects)
        {
            if (obj != null)
                obj.SetActive(isToggled);
        }

        // �t�g�iOFF��ON��OFF�j
        foreach (GameObject obj in inverseObjects)
        {
            if (obj != null)
                obj.SetActive(!isToggled);
        }
    }
}
