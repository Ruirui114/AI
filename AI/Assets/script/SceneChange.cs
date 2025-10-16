using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string sceneName;

    // UIƒ{ƒ^ƒ“‚©‚ç‚±‚ÌŠÖ”‚ğŒÄ‚Ô
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
