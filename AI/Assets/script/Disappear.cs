using UnityEngine;

public class Disappear : MonoBehaviour
{
    [Header("出したり消したりするオブジェクト")]
    public GameObject[] targetObjects;

    void Update()
    {
        // 左Shiftが押された瞬間にトグル
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleObjects();
        }
    }

    void ToggleObjects()
    {
        if (targetObjects == null || targetObjects.Length == 0)
            return;

        // 最初のオブジェクトの状態を基準に反転
        bool newState = !targetObjects[0].activeSelf;

        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(newState);
        }
    }
}
