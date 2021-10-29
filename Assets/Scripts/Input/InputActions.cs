// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""751de41a-5ab8-4c55-8d2f-f18a5920df02"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2642e2be-aadb-4b2a-a806-f50cae045a97"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""3a310775-7b54-41ff-b3fd-35bdf0944344"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""fcc4632e-96fb-4d87-bbf4-72921e952d16"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon1"",
                    ""type"": ""Value"",
                    ""id"": ""baf2d9a8-c724-462a-b50f-9ba35cb524bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon2"",
                    ""type"": ""Value"",
                    ""id"": ""94dcea10-099f-48bc-a0bc-194cb35fa9fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon3"",
                    ""type"": ""Value"",
                    ""id"": ""2e4f7214-976e-44c3-9bd5-b4fa28f6b95e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2c009387-9523-41ca-b360-d65008a6f4d7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""750accba-a448-4239-b6f7-1087bc57958e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6fde233a-d3f3-44e8-ac54-6df0b6f314b1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""201b9782-5f5b-4d42-a7ac-c77a6b1f4bbf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3b8e3017-ba7c-404a-be56-52cc5231ad11"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""129ab6ab-e9bb-414c-9598-5ea448036799"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e82895a-16d2-4611-ba84-7da68895d08a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f98cb315-1835-40f3-949e-237708b92f0c"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f1dabce-1a53-4d96-ba51-ccab9a43d6e9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2d61977-398a-463f-8470-9ad6bfc1119b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shortcut Keys"",
            ""id"": ""bc4a06c2-7e9a-4638-9a79-abe6fb301ce1"",
            ""actions"": [
                {
                    ""name"": ""Shop Exit"",
                    ""type"": ""Value"",
                    ""id"": ""4f4d8f1e-87b6-47e2-a622-432566b229ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shop"",
                    ""type"": ""Value"",
                    ""id"": ""73a48374-2641-419c-a44f-51abcc1d3f31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next Round"",
                    ""type"": ""Value"",
                    ""id"": ""f2fbd02a-1f7d-47ad-803b-61fa5e573d6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f167c48-ceb1-48bd-9a78-0de1c479e70e"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d94c295-a7a5-434b-b5b6-2d1eaed9ec6d"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Next Round"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0393b8f6-a6ed-4601-a892-c80838ecc636"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Shop Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause"",
            ""id"": ""a3554111-a355-4f0a-9f1a-5646f14fbbfc"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2836613a-9d09-4195-b9a7-b21f99c0aa78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""08c180af-e184-4c64-a4df-82a1337305f2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_Weapon1 = m_Gameplay.FindAction("Weapon1", throwIfNotFound: true);
        m_Gameplay_Weapon2 = m_Gameplay.FindAction("Weapon2", throwIfNotFound: true);
        m_Gameplay_Weapon3 = m_Gameplay.FindAction("Weapon3", throwIfNotFound: true);
        // Shortcut Keys
        m_ShortcutKeys = asset.FindActionMap("Shortcut Keys", throwIfNotFound: true);
        m_ShortcutKeys_ShopExit = m_ShortcutKeys.FindAction("Shop Exit", throwIfNotFound: true);
        m_ShortcutKeys_Shop = m_ShortcutKeys.FindAction("Shop", throwIfNotFound: true);
        m_ShortcutKeys_NextRound = m_ShortcutKeys.FindAction("Next Round", throwIfNotFound: true);
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Pause = m_Pause.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_Weapon1;
    private readonly InputAction m_Gameplay_Weapon2;
    private readonly InputAction m_Gameplay_Weapon3;
    public struct GameplayActions
    {
        private @InputActions m_Wrapper;
        public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @Weapon1 => m_Wrapper.m_Gameplay_Weapon1;
        public InputAction @Weapon2 => m_Wrapper.m_Gameplay_Weapon2;
        public InputAction @Weapon3 => m_Wrapper.m_Gameplay_Weapon3;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Weapon1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon1;
                @Weapon1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon1;
                @Weapon1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon1;
                @Weapon2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon2;
                @Weapon2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon2;
                @Weapon2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon2;
                @Weapon3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon3;
                @Weapon3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon3;
                @Weapon3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon3;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Weapon1.started += instance.OnWeapon1;
                @Weapon1.performed += instance.OnWeapon1;
                @Weapon1.canceled += instance.OnWeapon1;
                @Weapon2.started += instance.OnWeapon2;
                @Weapon2.performed += instance.OnWeapon2;
                @Weapon2.canceled += instance.OnWeapon2;
                @Weapon3.started += instance.OnWeapon3;
                @Weapon3.performed += instance.OnWeapon3;
                @Weapon3.canceled += instance.OnWeapon3;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Shortcut Keys
    private readonly InputActionMap m_ShortcutKeys;
    private IShortcutKeysActions m_ShortcutKeysActionsCallbackInterface;
    private readonly InputAction m_ShortcutKeys_ShopExit;
    private readonly InputAction m_ShortcutKeys_Shop;
    private readonly InputAction m_ShortcutKeys_NextRound;
    public struct ShortcutKeysActions
    {
        private @InputActions m_Wrapper;
        public ShortcutKeysActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ShopExit => m_Wrapper.m_ShortcutKeys_ShopExit;
        public InputAction @Shop => m_Wrapper.m_ShortcutKeys_Shop;
        public InputAction @NextRound => m_Wrapper.m_ShortcutKeys_NextRound;
        public InputActionMap Get() { return m_Wrapper.m_ShortcutKeys; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShortcutKeysActions set) { return set.Get(); }
        public void SetCallbacks(IShortcutKeysActions instance)
        {
            if (m_Wrapper.m_ShortcutKeysActionsCallbackInterface != null)
            {
                @ShopExit.started -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnShopExit;
                @ShopExit.performed -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnShopExit;
                @ShopExit.canceled -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnShopExit;
                @Shop.started -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnShop;
                @Shop.performed -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnShop;
                @Shop.canceled -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnShop;
                @NextRound.started -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnNextRound;
                @NextRound.performed -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnNextRound;
                @NextRound.canceled -= m_Wrapper.m_ShortcutKeysActionsCallbackInterface.OnNextRound;
            }
            m_Wrapper.m_ShortcutKeysActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ShopExit.started += instance.OnShopExit;
                @ShopExit.performed += instance.OnShopExit;
                @ShopExit.canceled += instance.OnShopExit;
                @Shop.started += instance.OnShop;
                @Shop.performed += instance.OnShop;
                @Shop.canceled += instance.OnShop;
                @NextRound.started += instance.OnNextRound;
                @NextRound.performed += instance.OnNextRound;
                @NextRound.canceled += instance.OnNextRound;
            }
        }
    }
    public ShortcutKeysActions @ShortcutKeys => new ShortcutKeysActions(this);

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_Pause;
    public struct PauseActions
    {
        private @InputActions m_Wrapper;
        public PauseActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Pause_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
        void OnWeapon3(InputAction.CallbackContext context);
    }
    public interface IShortcutKeysActions
    {
        void OnShopExit(InputAction.CallbackContext context);
        void OnShop(InputAction.CallbackContext context);
        void OnNextRound(InputAction.CallbackContext context);
    }
    public interface IPauseActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
