using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string sceneName;

    // UI�{�^�����炱�̊֐����Ă�
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
