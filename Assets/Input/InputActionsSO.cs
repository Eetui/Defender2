using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "InputActionsSO", menuName = "ScriptableObjects/InputActionsSO")]
public class InputActionsSO : ScriptableObject, InputActions.IGameplayActions, InputActions.IShortcutKeysActions, InputActions.IPauseActions
{
    private InputActions _inputActions;

    // Assign delegate{} to events to initialise them with an empty delegate
    // so we can skip the null check when we use them

    // Gameplay
    public event UnityAction<Vector2> OnLookEvent = delegate { };
    public event UnityAction<Vector2> OnMoveEvent = delegate { };
    public event UnityAction OnShootEvent = delegate { };
    public event UnityAction OnShootCanceledEvent = delegate { };

    public event UnityAction OnWeaponSelect1 = delegate { };
    public event UnityAction OnWeaponSelect2 = delegate { };
    public event UnityAction OnWeaponSelect3 = delegate { };

    //Shortcuts
    public event UnityAction OnShopOpenEvent = delegate { };
    public event UnityAction OnShopCloseEvent = delegate { };
    public event UnityAction OnNextRoundEvent = delegate { };

    //Pause
    public event UnityAction OnPauseEvent = delegate { };

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputActions();
            _inputActions.Gameplay.SetCallbacks(this);
            _inputActions.ShortcutKeys.SetCallbacks(this);
            _inputActions.Pause.SetCallbacks(this);
        }

        EnableAllInputs();
    }

    private void OnDisable() => DisableAllInput();

    public void OnWeapon1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnWeaponSelect1.Invoke();
        }
    }
    public void OnWeapon2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnWeaponSelect2.Invoke();
        }
    }
    public void OnWeapon3(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnWeaponSelect3.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context) => OnLookEvent.Invoke(context.ReadValue<Vector2>());

    public void OnMovement(InputAction.CallbackContext context) => OnMoveEvent.Invoke(context.ReadValue<Vector2>());

    public void OnShoot(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OnShootEvent.Invoke();
                break;
            case InputActionPhase.Canceled:
                OnShootCanceledEvent.Invoke();
                break;
        }
    }

    public void OnShopExit(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnShopCloseEvent.Invoke();
        }
    }
    public void OnShop(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnShopOpenEvent.Invoke();
        }
    }
    public void OnNextRound(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnNextRoundEvent.Invoke();
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnPauseEvent.Invoke();
        }
    }

    public void EnableGameplayInput() => _inputActions.Gameplay.Enable();

    public void DisableGameplayInput() => _inputActions.Gameplay.Disable();

    public void EnableShortcutInput() => _inputActions.ShortcutKeys.Enable();

    public void DisableShortcutInput() => _inputActions.ShortcutKeys.Disable();

    public void DisablePauseInput() => _inputActions.Pause.Disable();

    public void EnablePauseInput() => _inputActions.Pause.Enable();

    public void DisableAllInput()
    {
        _inputActions.Gameplay.Disable();
        _inputActions.Pause.Disable();
        _inputActions.ShortcutKeys.Disable();
    }

    public void EnableAllInputs()
    {
        _inputActions.Gameplay.Enable();
        _inputActions.Pause.Enable();
        _inputActions.ShortcutKeys.Enable();
    }
}
