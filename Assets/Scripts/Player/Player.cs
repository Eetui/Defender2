using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionsSO _inputActions;
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

    private ObjectPooler _objectPooler;

    private void OnEnable()
    {
        _inputActions.OnShootEvent += OnShoot;
        _inputActions.OnShootCanceledEvent += OnShootCanceled;

        _inputActions.OnWeaponSelect1 += ActiveWeapon1;
        _inputActions.OnWeaponSelect2 += ActiveWeapon2;
        _inputActions.OnWeaponSelect3 += ActiveWeapon3;
        _inventory.OnEmptyInventory += ActiveWeapon1;

        OnGunShot.AddListener(() => ShakeCamera(CurrentItem));
        onFireGunShot.AddListener(() => ShakeCamera(CurrentItem));

        _inventory.ResetInventory();
    }

    private void OnDisable()
    {
        _inputActions.OnShootEvent -= OnShoot;
        _inputActions.OnShootCanceledEvent -= OnShootCanceled;

        _inputActions.OnWeaponSelect1 -= ActiveWeapon1;
        _inputActions.OnWeaponSelect2 -= ActiveWeapon2;
        _inputActions.OnWeaponSelect3 -= ActiveWeapon3;
        _inventory.OnEmptyInventory -= ActiveWeapon1;

        OnGunShot.RemoveAllListeners();
    }

    private void Start() => ActiveWeapon1();

    private void Update()
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
        }
        else
        {
            _currentItem = default;
        }

        OnActiveItemChanged.Invoke();
    }

    private void ActiveWeapon1()
    {
        SetActiveItem(0);
    }

    private void ActiveWeapon2()
    {
        SetActiveItem(1);
    }

    private void ActiveWeapon3()
    {
        SetActiveItem(2);
    }

    private void ShakeCamera(ItemSO item)
    {
        if (item is GunSO gun)
            _cameraShake.ShotCameraShake(gun.Damage);
    }
}
