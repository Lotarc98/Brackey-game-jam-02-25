//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input Actions/PlayerControls1.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls1: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls1"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2e68f179-7145-4f5d-bd15-d8cb84f9fc9c"",
            ""actions"": [
                {
                    ""name"": ""OnMovePlayer1"",
                    ""type"": ""Value"",
                    ""id"": ""59d41eaa-0a38-4639-9f86-8bfd1043267a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""InteractPlayer1"",
                    ""type"": ""Button"",
                    ""id"": ""2d1d0b6c-c672-435b-95f9-a7d7c8ddc3e5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RevivePlayer1"",
                    ""type"": ""Button"",
                    ""id"": ""bbb425f0-219f-4a6b-8535-912ae62abb01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""OnMove"",
                    ""id"": ""106fb687-457a-4e5a-9abc-9af48373d510"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMovePlayer1"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""47eb383d-7ba8-49fb-bdf6-bd05df70f4cf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMovePlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""60f9a6ac-d487-4a5e-80c3-14e623cbfe65"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMovePlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2646ff4d-cfe6-4b37-b380-a42a62a927d9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMovePlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a45aeeda-c8c9-4a9d-bc97-180fd9edd342"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMovePlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f7238f6d-2534-44c7-8bf0-a4872ce6a31b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractPlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb91c0e5-b221-45c2-b461-e3ec158721d0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RevivePlayer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_OnMovePlayer1 = m_Gameplay.FindAction("OnMovePlayer1", throwIfNotFound: true);
        m_Gameplay_InteractPlayer1 = m_Gameplay.FindAction("InteractPlayer1", throwIfNotFound: true);
        m_Gameplay_RevivePlayer1 = m_Gameplay.FindAction("RevivePlayer1", throwIfNotFound: true);
    }

    ~@PlayerControls1()
    {
        UnityEngine.Debug.Assert(!m_Gameplay.enabled, "This will cause a leak and performance issues, PlayerControls1.Gameplay.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_OnMovePlayer1;
    private readonly InputAction m_Gameplay_InteractPlayer1;
    private readonly InputAction m_Gameplay_RevivePlayer1;
    public struct GameplayActions
    {
        private @PlayerControls1 m_Wrapper;
        public GameplayActions(@PlayerControls1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnMovePlayer1 => m_Wrapper.m_Gameplay_OnMovePlayer1;
        public InputAction @InteractPlayer1 => m_Wrapper.m_Gameplay_InteractPlayer1;
        public InputAction @RevivePlayer1 => m_Wrapper.m_Gameplay_RevivePlayer1;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @OnMovePlayer1.started += instance.OnOnMovePlayer1;
            @OnMovePlayer1.performed += instance.OnOnMovePlayer1;
            @OnMovePlayer1.canceled += instance.OnOnMovePlayer1;
            @InteractPlayer1.started += instance.OnInteractPlayer1;
            @InteractPlayer1.performed += instance.OnInteractPlayer1;
            @InteractPlayer1.canceled += instance.OnInteractPlayer1;
            @RevivePlayer1.started += instance.OnRevivePlayer1;
            @RevivePlayer1.performed += instance.OnRevivePlayer1;
            @RevivePlayer1.canceled += instance.OnRevivePlayer1;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @OnMovePlayer1.started -= instance.OnOnMovePlayer1;
            @OnMovePlayer1.performed -= instance.OnOnMovePlayer1;
            @OnMovePlayer1.canceled -= instance.OnOnMovePlayer1;
            @InteractPlayer1.started -= instance.OnInteractPlayer1;
            @InteractPlayer1.performed -= instance.OnInteractPlayer1;
            @InteractPlayer1.canceled -= instance.OnInteractPlayer1;
            @RevivePlayer1.started -= instance.OnRevivePlayer1;
            @RevivePlayer1.performed -= instance.OnRevivePlayer1;
            @RevivePlayer1.canceled -= instance.OnRevivePlayer1;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnOnMovePlayer1(InputAction.CallbackContext context);
        void OnInteractPlayer1(InputAction.CallbackContext context);
        void OnRevivePlayer1(InputAction.CallbackContext context);
    }
}
