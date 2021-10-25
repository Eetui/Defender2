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

    public virtual void Start()
    {
        Destroy(gameObject, 5f);
    }

    public virtual void FixedUpdate()
    {
        _rb.velocity = transform.up * AmmoSO.Speed;
    }

    public virtual void SetUpBullet(AmmoSO ammoSO, float damage)
    {
        AmmoSO = ammoSO;
        Damage = damage;
        _spriteRenderer.sprite = ammoSO.Sprite;
    }
}
