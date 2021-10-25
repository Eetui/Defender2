 using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStats _stats;

    [SerializeField] private EnemyRuntimeSet runtimeSet;
    public EnemyStats Stats => _stats;

    private UnitHealth health;

    private void OnEnable()
    {
        runtimeSet.Add(this);
    }

    private void OnDisable()
    {
        runtimeSet.Remove(this);
    }

    private void Start()
    {
        health = GetComponent<UnitHealth>();
        health.Init(_stats.MaxHealth);
        GetComponentInChildren<SpriteRenderer>().sprite = _stats.Icon;

        health.OnDie.AddListener(Kill);
    }

    private void OnDestroy()
    {
        health.OnDie.RemoveListener(Kill);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            if(!(bullet is FireBullet))
            {
                health.TakeDamage(bullet.Damage);
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag("Base"))
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            if (bullet is FireBullet fire)
            {
                health.TakeDamage(fire.Damage);
            }
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
