using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvas2 : MonoBehaviour
{

    CanvasGroup canvasGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        SetCanvasGroup();
    }


    void SetCanvasGroup()
    {
        if (canvasGroup == null)
            canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }


    public void FadeNow()
    {
        SetCanvasGroup();

        if (canvasGroup.gameObject.activeInHierarchy)
        {
            StartCoroutine(FadeCoroutine(Fade._out));
        }
        else
        {
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeCoroutine(Fade._in));
        }
    }
    

    enum Fade { _in, _out}
    IEnumerator FadeCoroutine(Fade fade)
    {
        float startAlpha = canvasGroup.alpha;
        float endAlpha = 0;
        if (fade == Fade._in)
            endAlpha = 1f;

        float duration = 0f;

        while(duration < fadeDuration)
        {
            duration += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, duration / fadeDuration);
            yield return new WaitForEndOfFrame();
        }

        if (fade == Fade._out)
            canvasGroup.gameObject.SetActive(false);
    }
}
