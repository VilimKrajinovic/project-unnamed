// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""10915f1b-6047-45e0-b77f-74782a902e3e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""626b3959-58a3-4005-bbf9-ba087828115d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1628e3a6-a427-4f1c-822b-dd1602a347c4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5969ee8a-2bcd-4136-8dec-2c711b864666"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b1cd9bd4-aedb-4f9f-a6f2-e187c6d18b8d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e445006d-e582-4448-83d9-2cc6a72c8ddd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2c289fc0-e965-4af8-b5f2-06970a443d9b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""90fb789b-d3d5-4046-99ee-c3903c231c1b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""61f6301f-e064-4868-b072-a18afeb7547c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d2024c8-1152-42b8-a110-bd7e37342c4e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""f0f3d980-4954-45cf-910f-1d16cd85e544"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""8f7eb13c-dac7-454d-a550-c21bd2f571d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light Attack"",
                    ""type"": ""Button"",
                    ""id"": ""7b3b48b4-a1c5-4185-aa20-9420a4083d31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Heavy Attack"",
                    ""type"": ""Button"",
                    ""id"": ""63d74875-f5d8-4037-bbcc-5825e1ee8ffe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""09559dca-a049-4c16-af90-ab1b8e8bf857"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""990cbbc9-7b96-43c3-8b45-2d49b9b7e2a5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Light Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7c3f186-e51d-4607-a24d-c663cbdb8937"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heavy Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Inventory"",
            ""id"": ""724bb91f-2280-49a9-8177-0363dbd9474e"",
            ""actions"": [
                {
                    ""name"": ""QuickSlotRight"",
                    ""type"": ""Button"",
                    ""id"": ""068e7aa6-1d15-47e6-920e-77692457ab91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuickSlotLeft"",
                    ""type"": ""Button"",
                    ""id"": ""3f5b4de7-2213-4c66-a259-773127037ee4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d997bccd-b0e7-4e73-a65e-f1275b1d33cf"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlotRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""700d7561-edb4-48fc-9b79-3eaf015799ec"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuickSlotLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
        m_PlayerActions_LightAttack = m_PlayerActions.FindAction("Light Attack", throwIfNotFound: true);
        m_PlayerActions_HeavyAttack = m_PlayerActions.FindAction("Heavy Attack", throwIfNotFound: true);
        // Player Inventory
        m_PlayerInventory = asset.FindActionMap("Player Inventory", throwIfNotFound: true);
        m_PlayerInventory_QuickSlotRight = m_PlayerInventory.FindAction("QuickSlotRight", throwIfNotFound: true);
        m_PlayerInventory_QuickSlotLeft = m_PlayerInventory.FindAction("QuickSlotLeft", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Roll;
    private readonly InputAction m_PlayerActions_LightAttack;
    private readonly InputAction m_PlayerActions_HeavyAttack;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
        public InputAction @LightAttack => m_Wrapper.m_PlayerActions_LightAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_PlayerActions_HeavyAttack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @LightAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLightAttack;
                @HeavyAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnHeavyAttack;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // Player Inventory
    private readonly InputActionMap m_PlayerInventory;
    private IPlayerInventoryActions m_PlayerInventoryActionsCallbackInterface;
    private readonly InputAction m_PlayerInventory_QuickSlotRight;
    private readonly InputAction m_PlayerInventory_QuickSlotLeft;
    public struct PlayerInventoryActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerInventoryActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @QuickSlotRight => m_Wrapper.m_PlayerInventory_QuickSlotRight;
        public InputAction @QuickSlotLeft => m_Wrapper.m_PlayerInventory_QuickSlotLeft;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInventoryActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInventoryActions instance)
        {
            if (m_Wrapper.m_PlayerInventoryActionsCallbackInterface != null)
            {
                @QuickSlotRight.started -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnQuickSlotRight;
                @QuickSlotRight.performed -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnQuickSlotRight;
                @QuickSlotRight.canceled -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnQuickSlotRight;
                @QuickSlotLeft.started -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnQuickSlotLeft;
                @QuickSlotLeft.performed -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnQuickSlotLeft;
                @QuickSlotLeft.canceled -= m_Wrapper.m_PlayerInventoryActionsCallbackInterface.OnQuickSlotLeft;
            }
            m_Wrapper.m_PlayerInventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @QuickSlotRight.started += instance.OnQuickSlotRight;
                @QuickSlotRight.performed += instance.OnQuickSlotRight;
                @QuickSlotRight.canceled += instance.OnQuickSlotRight;
                @QuickSlotLeft.started += instance.OnQuickSlotLeft;
                @QuickSlotLeft.performed += instance.OnQuickSlotLeft;
                @QuickSlotLeft.canceled += instance.OnQuickSlotLeft;
            }
        }
    }
    public PlayerInventoryActions @PlayerInventory => new PlayerInventoryActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnLightAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
    }
    public interface IPlayerInventoryActions
    {
        void OnQuickSlotRight(InputAction.CallbackContext context);
        void OnQuickSlotLeft(InputAction.CallbackContext context);
    }
}
