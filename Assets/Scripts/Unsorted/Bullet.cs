using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AmmoSO AmmoSO { get; private set; }
    public float Damage { get; private set; }

    internal Rigidbody2D _rb;
    internal SpriteRenderer _spriteRenderer;

    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void FixedUpdate()
    {
        _rb.velocity = transform.up * AmmoSO.Speed;

        if (!_spriteRenderer.isVisible)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void SetUpBullet(AmmoSO ammoSO, float damage)
    {
        AmmoSO = ammoSO;
        Damage = damage;
        _spriteRenderer.sprite = ammoSO.Sprite;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {

            var particleEffect = ObjectPooler.Instance.GetObject(AmmoSO.ParticleEffecet);
            particleEffect.transform.position = collision.ClosestPoint(transform.position);
            gameObject.SetActive(false);
        }
    }
}
