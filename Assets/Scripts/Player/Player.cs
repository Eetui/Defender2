using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input;
    public UnityAction OnActiveItemChanged = delegate { };

    public ItemSO CurrentItem { get { return _currentItem; } }
    private ItemSO _currentItem;

    [SerializeField] private InventorySO _inventory;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private Transform _gunShellPoint;
    [SerializeField] private CameraShake _cameraShake;

    public UnityEvent OnGunShot;
    public UnityEvent onFireGunShot;

    private float _timer;
    private bool _shoot;

    private void OnEnable()
    {
        _input.OnShootEvent += OnShoot;
        _input.OnShootCanceledEvent += OnShootCanceled;
        _input.OnWeaponSelect1 += () => SetActiveItem(0);
        _input.OnWeaponSelect2 += () => SetActiveItem(1);
        _input.OnWeaponSelect3 += () => SetActiveItem(2);

        _inventory.OnEmptyInventory += () => SetActiveItem(0);

        OnGunShot.AddListener(() => ShakeCamera(CurrentItem));
        onFireGunShot.AddListener(() => ShakeCamera(CurrentItem));

        _inventory.Reset();
    }

    private void OnDisable()
    {
        _input.OnShootEvent -= OnShoot;
        _input.OnShootCanceledEvent -= OnShootCanceled;

        _input.OnWeaponSelect1 -= () => SetActiveItem(0);
        _input.OnWeaponSelect2 -= () => SetActiveItem(1);
        _input.OnWeaponSelect3 -= () => SetActiveItem(2);
        _inventory.OnEmptyInventory -= () => SetActiveItem(0);

        OnGunShot.RemoveAllListeners();
    }

    private void Start() => SetActiveItem(0);

    private void Update()
    {
        ShootWeapon();
    }

    private void ShootWeapon()
    {
        _timer += Time.deltaTime;

        if (_currentItem is GunSO gun)
        {
            if (CanShoot(gun))
            {
                gun.Shoot(_gunPoint.position, _gunPoint.rotation, _gunShellPoint.position);

                if (gun.Bullet is FireBullet)
                {
                    onFireGunShot.Invoke();
                }
                else
                {
                    OnGunShot.Invoke();
                }

                _timer = 0;
            }
        }
    }

    private void OnShoot() => _shoot = true;

    private void OnShootCanceled() => _shoot = false;

    private bool CanShoot(GunSO gun) => _shoot && (1 / gun.FireRate) < _timer;

    public void SetActiveItem(int itemSlot)
    {
        if (_inventory.Inventory[itemSlot] != null)
        {
            _currentItem = _inventory.Inventory[itemSlot];
            OnActiveItemChanged.Invoke();
            return;
        }

        _currentItem = default;
        OnActiveItemChanged.Invoke();
    }

    private void ShakeCamera(ItemSO item)
    {
        if (item is GunSO gun) _cameraShake.ShotCameraShake(gun.Damage);
    }
}
