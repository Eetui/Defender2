using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Items/Gun")]
public class GunSO : ItemSO, IShootable
{
    [SerializeField] private int _level;
    private int _currentLevel;

    [SerializeField] private float _baseUpgradeCost;

    [SerializeField] private float _baseFireRate;
    [SerializeField] private float _fireRateGrowth;

    [SerializeField] private float _baseDamage;
    [SerializeField] private float _damageGrowth;

    [SerializeField] private AmmoSO _ammo;
     

    #region Properties
    public int Level => _currentLevel;

    public float FireRate => _baseFireRate + (Level * _fireRateGrowth);

    public float Damage => _baseDamage + (Level * _damageGrowth);

    public float BaseFireRate => _baseFireRate;

    public float BaseDamage => _baseDamage;

    public float FireRateGrowth => _fireRateGrowth;

    public float DamageGrowth => _damageGrowth;

    public float UpgradeCost => (_baseUpgradeCost + (Level * _baseUpgradeCost));

    public float BaseUpgradeCost => _baseUpgradeCost;

    public override float SellAmount => (_cost + (Level * _baseUpgradeCost)) / 2;

    public AmmoSO Ammo => _ammo;

    public Bullet Bullet { get; private set; }

    #endregion

    private void OnEnable()
    {
        Reset();
    }

    public override void Reset() => _currentLevel = _level;

    [ContextMenu("Level Up")]
    public void LevelUp()
    {
        _currentLevel++;
    }

    public void Shoot(Vector3 ShootingPoint, Quaternion quaternion)
    {
        var ammo = ObjectPooler.Instance.GetObject(Ammo.baseBulletPrefab);
        ammo.transform.position = ShootingPoint;
        ammo.transform.rotation = quaternion;

        if (ammo.TryGetComponent(out Bullet bullet))
        {
            bullet.SetUpBullet(Ammo, Damage);
            Bullet = bullet;
        }

    }
}
