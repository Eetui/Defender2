using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectDisableAfterPlaying : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    private void Awake()
    {
        if (ps == null)
        {
            ps = GetComponent<ParticleSystem>();
        }
    }

    private void Update()
    {
        if (!ps.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
