using UnityEngine;

public class Disappear2 : MonoBehaviour
{
    [Header("�ʏ�ON/OFF����I�u�W�F�N�g�Q")]
    public GameObject[] normalObjects;

    [Header("�t�^�C�~���O�Ő؂�ւ���I�u�W�F�N�g�Q")]
    public GameObject[] inverseObjects;

    [Header("�؂�ւ��Ԋu�i�b�j")]
    public float interval = 1.0f;

    private bool isToggled = false; // ���݂̏�ԋL�^�ifalse = �ʏ�ON�j

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // ���Ԋu�ŕ\���E��\����؂�ւ�
        if (timer >= interval)
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
            timer = 0f;
        }
    }
}
