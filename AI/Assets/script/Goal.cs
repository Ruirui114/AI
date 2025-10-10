using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // ���̃V�[����
    public float delayBeforeFade = 0.5f;       // �����~�܂鎞��
    public float fadeDuration = 1f;            // �t�F�[�h����

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return; // ��d����h�~
        if (collision.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(GoalSequence());
        }
    }

    private System.Collections.IEnumerator GoalSequence()
    {
        // ������~
        yield return new WaitForSeconds(delayBeforeFade);

        // �t�F�[�h�A�E�g�J�n
        if (Fade.Instance != null)
        {
            yield return Fade.Instance.FadeOut(fadeDuration);
        }

        // �V�[���؂�ւ�
        SceneManager.LoadScene(nextSceneName);
    }
}
