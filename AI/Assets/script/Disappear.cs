using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("通常ON/OFFするオブジェクト群")]
    public GameObject[] normalObjects;

    [Header("逆タイミングで切り替えるオブジェクト群")]
    public GameObject[] inverseObjects;

    [Header("切り替えキー")]
    public KeyCode toggleKey = KeyCode.LeftShift;

    private bool isToggled = false; // 現在の状態記録（false = 通常ON）

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
    }
}
