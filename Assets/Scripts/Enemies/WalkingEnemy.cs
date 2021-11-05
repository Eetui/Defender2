using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    private Enemy _enemy;
    private Rigidbody2D _rb;
    private Vector3 _direction;
    private float _speed;
    [SerializeField] private float slowMult = 0.5f;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _speed = _enemy.Stats.Speed;
    }

    private void FixedUpdate()
    {
        _rb.velocity = (Vector3.zero - transform.position).normalized * _speed;
    }

    public void Slow(float duration)
    {
        StartCoroutine(SlowCoroutine(duration));
    }

    private IEnumerator SlowCoroutine(float duration)
    {
        float startSpeed = _speed;
        _speed *= slowMult;
        yield return new WaitForSeconds(duration);
        _speed = startSpeed;
    }
}
