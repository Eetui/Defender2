using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D rb;
    private Vector3 direction;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        direction = (Vector3.zero - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * enemy.Stats.Speed;
    }


}
