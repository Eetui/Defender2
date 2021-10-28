using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    private ParticleSystem.MainModule mainModeule;
    private ParticleSystem.LimitVelocityOverLifetimeModule limitspeed;
    private ParticleSystemRenderer particleRenderer;
    private bool flag;
    private float timer;
    private float randomTime;

    private void Awake()
    {
        if(!ps)
        {
            ps = GetComponent<ParticleSystem>();
        }

        particleRenderer = GetComponent<ParticleSystemRenderer>();
        mainModeule = ps.main;
        limitspeed = ps.limitVelocityOverLifetime;
    }

    private void OnEnable()
    {
        mainModeule.gravityModifier = 2f;
        limitspeed.limit = 30;
        limitspeed.dampen = 1;
        flag = false;
        randomTime = Random.Range(0.9f,1.1f);
        particleRenderer.sortingLayerName = "Top";
    }

    private void Update()
    {
        if (flag) return;

        timer += Time.deltaTime;

        if (timer > randomTime)
        {
            mainModeule.gravityModifier = 0f;
            limitspeed.limit = 0;
            limitspeed.dampen = 1;
            flag = true;
            particleRenderer.sortingLayerName = "Bot";
            timer = 0;
        }
    }
}
