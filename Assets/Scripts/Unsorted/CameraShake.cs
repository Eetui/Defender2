using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCam;

    [SerializeField] private float shotShakeDurationReducer = 20;
    [SerializeField] private float shotShakenIntensityReducer = 10;
    private bool damageShakeEnabled;


    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShotCameraShake(float shakeIntensity)
    {
        if (!damageShakeEnabled)
        {
            StopAllCoroutines();
            StartCoroutine(LerpShake(shakeIntensity / shotShakeDurationReducer, shakeIntensity / shotShakenIntensityReducer));
        }
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

    public void DamageShake(float shakeIntensity)
    {
        damageShakeEnabled = true;
        StopAllCoroutines();
        StartCoroutine(DamageShakeLerp(shakeIntensity));
    }

    private IEnumerator DamageShakeLerp(float shakeIntensity)
    {
        float time = 0;
        var camPerlinNoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        while (time < 1)
        {
            camPerlinNoise.m_AmplitudeGain = Mathf.Lerp(shakeIntensity, 0f, time / 1);
            time += Time.deltaTime;
            yield return null;
        }

        camPerlinNoise.m_AmplitudeGain = 0f;
        damageShakeEnabled = false;
    }

}
