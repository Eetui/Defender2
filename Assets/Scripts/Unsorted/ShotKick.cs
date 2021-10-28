using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotKick : MonoBehaviour
{
    [SerializeField] private float kickAmount;
    [SerializeField] private float duration;

    public void GunKick()
    {
        StopAllCoroutines();
        StartCoroutine(LerpPosition(kickAmount, duration));
    }

    IEnumerator LerpPosition(float kick, float duration)
    {
        float time = 0;
        transform.localPosition = Vector2.zero;
        Vector2 endValue = transform.localPosition;
        Vector2 startValue = new Vector2(transform.localPosition.x, transform.localPosition.y - kick);

        while (time < duration)
        {
            transform.localPosition = Vector2.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = endValue;
    }
}
