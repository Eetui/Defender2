using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeColor : MonoBehaviour
{
    public Color targetColor = new Color(0, 0, 0, 0);
    [SerializeField] private TMP_Text textToFade;
    [SerializeField] private float fadeDuration;

    private void OnEnable()
    {
        StartCoroutine(LerpColor(targetColor, fadeDuration));
    }

    IEnumerator LerpColor(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = textToFade.color;

        while (time < duration)
        {
            textToFade.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        textToFade.color = endValue;
        StartCoroutine(LerpColorWithDisable(startValue, fadeDuration));
    }

    IEnumerator LerpColorWithDisable(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = textToFade.color;

        while (time < duration)
        {
            textToFade.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        textToFade.color = endValue;
        gameObject.SetActive(false);
    }
}
