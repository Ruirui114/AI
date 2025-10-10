using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // 次のシーン名
    public float delayBeforeFade = 0.5f;       // 少し止まる時間
    public float fadeDuration = 1f;            // フェード時間

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return; // 二重判定防止
        if (collision.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(GoalSequence());
        }
    }

    private System.Collections.IEnumerator GoalSequence()
    {
        // 少し停止
        yield return new WaitForSeconds(delayBeforeFade);

        // フェードアウト開始
        if (Fade.Instance != null)
        {
            yield return Fade.Instance.FadeOut(fadeDuration);
        }

        // シーン切り替え
        SceneManager.LoadScene(nextSceneName);
    }
}
