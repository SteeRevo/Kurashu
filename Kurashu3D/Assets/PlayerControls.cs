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
            ""name"": ""PlayerBattleTurn"",
            ""id"": ""0dfc8d93-c454-4dd2-865f-3c66878e2ad1"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""514bd6fc-cd1f-4a88-a863-f800b1bae5d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""e777bba5-14ea-4ff4-8518-bb7bc24b509d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a806b1d1-85a5-4684-aea1-42960c6afcd4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7232c025-a967-4e8b-9b4c-3c4b3a5a6cc5"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88e98569-8ff3-4ae9-8b8c-fe277b865eee"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""a1505727-e667-491d-882d-a413f207995e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""98d64efb-a250-476f-8552-e5ea2afafddb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b7289408-f14d-436d-9728-0b892693df37"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""08a7170e-04b5-4d9d-af6d-838511c5f5f6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""72df1e58-6797-4fac-b015-c5ffb065d86f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerBattleTurn
        m_PlayerBattleTurn = asset.FindActionMap("PlayerBattleTurn", throwIfNotFound: true);
        m_PlayerBattleTurn_Select = m_PlayerBattleTurn.FindAction("Select", throwIfNotFound: true);
        m_PlayerBattleTurn_Cancel = m_PlayerBattleTurn.FindAction("Cancel", throwIfNotFound: true);
        m_PlayerBattleTurn_Move = m_PlayerBattleTurn.FindAction("Move", throwIfNotFound: true);
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

    // PlayerBattleTurn
    private readonly InputActionMap m_PlayerBattleTurn;
    private IPlayerBattleTurnActions m_PlayerBattleTurnActionsCallbackInterface;
    private readonly InputAction m_PlayerBattleTurn_Select;
    private readonly InputAction m_PlayerBattleTurn_Cancel;
    private readonly InputAction m_PlayerBattleTurn_Move;
    public struct PlayerBattleTurnActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerBattleTurnActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_PlayerBattleTurn_Select;
        public InputAction @Cancel => m_Wrapper.m_PlayerBattleTurn_Cancel;
        public InputAction @Move => m_Wrapper.m_PlayerBattleTurn_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBattleTurn; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBattleTurnActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerBattleTurnActions instance)
        {
            if (m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnSelect;
                @Cancel.started -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnCancel;
                @Move.started -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerBattleTurnActions @PlayerBattleTurn => new PlayerBattleTurnActions(this);
    public interface IPlayerBattleTurnActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
