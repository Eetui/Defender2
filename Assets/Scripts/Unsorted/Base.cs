using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
public class Base : MonoBehaviour
{
    private UnitHealth health;

    private void Awake()
    {
        health = GetComponent<UnitHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            health.TakeDamage(enemy.Stats.Damage);
        }
    }
}
