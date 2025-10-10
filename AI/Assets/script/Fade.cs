using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Fade : MonoBehaviour
{
    public static Fade Instance;
    public Image fadeImage;  // 黒いUIイメージ
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // 初期状態：フェードイン（真っ黒→明るく）
        StartCoroutine(FadeIn(1f));
    }

    public IEnumerator FadeOut(float duration)
    {
        float t = 0f;
        Color c = fadeImage.color;
        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / duration);
            fadeImage.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeIn(float duration)
    {
        float t = 0f;
        Color c = fadeImage.color;
        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, t / duration);
            fadeImage.color = c;
            yield return null;
        }
    }
}
