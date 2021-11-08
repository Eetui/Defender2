using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule _mainModeule;
    private ParticleSystem.LimitVelocityOverLifetimeModule _limitspeed;
    private ParticleSystem.RotationBySpeedModule _rotationSpeed;
    private ParticleSystemRenderer _particleRenderer;
    private bool _flag;
    private float _timer;
    private float _randomTime;

    private void Awake()
    {
        if(!_particleSystem)
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        _particleRenderer = GetComponent<ParticleSystemRenderer>();
        _mainModeule = _particleSystem.main;
        _limitspeed = _particleSystem.limitVelocityOverLifetime;
        _rotationSpeed = _particleSystem.rotationBySpeed;
    }

    private void OnEnable()
    {
        _randomTime = Random.Range(0.9f, 1.1f);
        var randomRotationSpeed = Random.Range(1, 50);
        SetParticleVariables(2f, 30f,1f, randomRotationSpeed, "Top", false);
    }


    private void Update()
    {
        if (_flag) return;

        _timer += Time.deltaTime;

        if (_timer > _randomTime)
        {
            SetParticleVariables(0f, 0f, 1f,0f, "Bot", true);
            _timer = 0;
        }
    }

    private void SetParticleVariables(float gravityModifier, float speedLimit, float speedDampen, float rotationMult, string sortinLayer, bool flag)
    {
        _rotationSpeed.z = rotationMult;
        _mainModeule.gravityModifier = gravityModifier;
        _limitspeed.limit = speedLimit;
        _limitspeed.dampen = speedDampen;
        _flag = flag;
        _particleRenderer.sortingLayerName = sortinLayer;
    }
}
