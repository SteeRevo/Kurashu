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
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""20751bd9-145b-4527-b973-5224a7c3de0c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""8f8da6e9-aef3-4707-8209-cc6071d187a2"",
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
                    ""id"": ""a9452c0c-3e19-4423-910d-0c1ac0dc4374"",
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
                    ""id"": ""46284595-ba9b-4a16-a5e1-8cd313b84e29"",
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
                    ""id"": ""a91ce046-6a94-415b-8671-f7639fc688bc"",
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
                    ""id"": ""421b5a32-0266-4676-977b-62b76293b75e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerBattleTurn
        m_PlayerBattleTurn = asset.FindActionMap("PlayerBattleTurn", throwIfNotFound: true);
        m_PlayerBattleTurn_Move = m_PlayerBattleTurn.FindAction("Move", throwIfNotFound: true);
        m_PlayerBattleTurn_Select = m_PlayerBattleTurn.FindAction("Select", throwIfNotFound: true);
        m_PlayerBattleTurn_Cancel = m_PlayerBattleTurn.FindAction("Cancel", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerBattleTurn_Move;
    private readonly InputAction m_PlayerBattleTurn_Select;
    private readonly InputAction m_PlayerBattleTurn_Cancel;
    public struct PlayerBattleTurnActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerBattleTurnActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerBattleTurn_Move;
        public InputAction @Select => m_Wrapper.m_PlayerBattleTurn_Select;
        public InputAction @Cancel => m_Wrapper.m_PlayerBattleTurn_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBattleTurn; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBattleTurnActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerBattleTurnActions instance)
        {
            if (m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnMove;
                @Select.started -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnSelect;
                @Cancel.started -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_PlayerBattleTurnActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public PlayerBattleTurnActions @PlayerBattleTurn => new PlayerBattleTurnActions(this);
    public interface IPlayerBattleTurnActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
    }
}
