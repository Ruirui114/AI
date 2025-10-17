using UnityEngine;

public class Disappear2 : MonoBehaviour
{
    [Header("通常ON/OFFするオブジェクト群")]
    public GameObject[] normalObjects;

    [Header("逆タイミングで切り替えるオブジェクト群")]
    public GameObject[] inverseObjects;

    [Header("切り替え間隔（秒）")]
    public float interval = 1.0f;

    private bool isToggled = false; // 現在の状態記録（false = 通常ON）

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // 一定間隔で表示・非表示を切り替え
        if (timer >= interval)
        {
            isToggled = !isToggled;

            // 通常組（ON→OFF→ON）
            foreach (GameObject obj in normalObjects)
            {
                if (obj != null)
                    obj.SetActive(isToggled);
            }

            // 逆組（OFF→ON→OFF）
            foreach (GameObject obj in inverseObjects)
            {
                if (obj != null)
                    obj.SetActive(!isToggled);
            }
            timer = 0f;
        }
    }
}
