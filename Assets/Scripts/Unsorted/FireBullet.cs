using System.Collections;
using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private Vector3 _startSize = new Vector3(0.1f, 0.1f, 1f);
    [SerializeField] private Vector3 _endSize = new Vector3(2f, 0.5f, 1f);
    [SerializeField] private float _duration = 2f;

    private float _speed;

    private void OnEnable()
    {
        if (AmmoSO != null)
        {
            _speed = AmmoSO.Speed;
            StartCoroutine(LerpSizeAndSpeed(_duration));
        }
    }

    private void Start()
    {
        _speed = AmmoSO.Speed;
        StartCoroutine(LerpSizeAndSpeed(_duration));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public override void FixedUpdate()
    {
        _rb.velocity = transform.up * _speed;
    }

    private IEnumerator LerpSizeAndSpeed(float duration)
    {
        float time = 0;
        float startSpeed = _speed;

        while (duration > time)
        {
            transform.localScale = Vector3.Lerp(_startSize, _endSize, time / duration);
            _speed = Mathf.Lerp(startSpeed, 0.05f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
