using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
public class Base : MonoBehaviour
{
    private UnitHealth health;
    [SerializeField] private GameObject hitParticle;

    private void Awake()
    {
        health = GetComponent<UnitHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            health.TakeDamage(enemy.Stats.Damage);
            var particle = ObjectPooler.Instance.GetObject(hitParticle);
            particle.transform.position = collision.transform.position;
        }
    }
}
