using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCam;
    private Coroutine coroutine;

    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShotCameraShake(float shakeIntensity)
    {
        StopAllCoroutines();
        StartCoroutine(LerpShake(shakeIntensity / 10, shakeIntensity / 5));
    }
    private IEnumerator LerpShake(float duration, float shakeIntensity)
    {
        float time = 0;
        var camPerlinNoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        while (time < duration)
        {
            camPerlinNoise.m_AmplitudeGain = Mathf.Lerp(shakeIntensity, 0f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        camPerlinNoise.m_AmplitudeGain = 0f;
    }
}
