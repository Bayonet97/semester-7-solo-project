// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerCharacters/PlayerControls.inputactions'

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
            ""name"": ""TwobControls"",
            ""id"": ""5ddc1293-11ad-4d41-99f0-778ead1b2f84"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0fc8aba7-d918-40b5-b057-89aea4b701c4"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""af6a55fd-bc8d-469b-9290-81f3b619d968"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e804b9df-1d81-4ef8-b596-039f1033cfe3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c558d4c1-ceb9-475d-be25-3e775fb29178"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""NinesControls"",
            ""id"": ""ff012881-6a79-477e-bdcf-35fd56e9d713"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fe44fe4b-850d-41f1-b24f-5a60cdb154f1"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1c933105-164e-4697-87a8-0cf788e2b51a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e4d6c953-eb3a-441a-b958-f6a113896ceb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25a65b11-24a9-4719-8950-7f6d087d0541"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuControls"",
            ""id"": ""44ffcf47-b1fe-4505-aa4a-4508cf1ffc8c"",
            ""actions"": [
                {
                    ""name"": ""ResetLevel"",
                    ""type"": ""Button"",
                    ""id"": ""695ae4eb-1e5d-49c1-aa96-449635333189"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e7bde10-6402-4528-a37c-263a18574b77"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TwobControls
        m_TwobControls = asset.FindActionMap("TwobControls", throwIfNotFound: true);
        m_TwobControls_Move = m_TwobControls.FindAction("Move", throwIfNotFound: true);
        m_TwobControls_Interact = m_TwobControls.FindAction("Interact", throwIfNotFound: true);
        // NinesControls
        m_NinesControls = asset.FindActionMap("NinesControls", throwIfNotFound: true);
        m_NinesControls_Move = m_NinesControls.FindAction("Move", throwIfNotFound: true);
        m_NinesControls_Interact = m_NinesControls.FindAction("Interact", throwIfNotFound: true);
        // MenuControls
        m_MenuControls = asset.FindActionMap("MenuControls", throwIfNotFound: true);
        m_MenuControls_ResetLevel = m_MenuControls.FindAction("ResetLevel", throwIfNotFound: true);
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

    // TwobControls
    private readonly InputActionMap m_TwobControls;
    private ITwobControlsActions m_TwobControlsActionsCallbackInterface;
    private readonly InputAction m_TwobControls_Move;
    private readonly InputAction m_TwobControls_Interact;
    public struct TwobControlsActions
    {
        private @PlayerControls m_Wrapper;
        public TwobControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TwobControls_Move;
        public InputAction @Interact => m_Wrapper.m_TwobControls_Interact;
        public InputActionMap Get() { return m_Wrapper.m_TwobControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TwobControlsActions set) { return set.Get(); }
        public void SetCallbacks(ITwobControlsActions instance)
        {
            if (m_Wrapper.m_TwobControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TwobControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TwobControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TwobControlsActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_TwobControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TwobControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TwobControlsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_TwobControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public TwobControlsActions @TwobControls => new TwobControlsActions(this);

    // NinesControls
    private readonly InputActionMap m_NinesControls;
    private INinesControlsActions m_NinesControlsActionsCallbackInterface;
    private readonly InputAction m_NinesControls_Move;
    private readonly InputAction m_NinesControls_Interact;
    public struct NinesControlsActions
    {
        private @PlayerControls m_Wrapper;
        public NinesControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_NinesControls_Move;
        public InputAction @Interact => m_Wrapper.m_NinesControls_Interact;
        public InputActionMap Get() { return m_Wrapper.m_NinesControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NinesControlsActions set) { return set.Get(); }
        public void SetCallbacks(INinesControlsActions instance)
        {
            if (m_Wrapper.m_NinesControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_NinesControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_NinesControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_NinesControlsActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_NinesControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_NinesControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_NinesControlsActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_NinesControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public NinesControlsActions @NinesControls => new NinesControlsActions(this);

    // MenuControls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_ResetLevel;
    public struct MenuControlsActions
    {
        private @PlayerControls m_Wrapper;
        public MenuControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResetLevel => m_Wrapper.m_MenuControls_ResetLevel;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @ResetLevel.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnResetLevel;
                @ResetLevel.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnResetLevel;
                @ResetLevel.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnResetLevel;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ResetLevel.started += instance.OnResetLevel;
                @ResetLevel.performed += instance.OnResetLevel;
                @ResetLevel.canceled += instance.OnResetLevel;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    public interface ITwobControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface INinesControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IMenuControlsActions
    {
        void OnResetLevel(InputAction.CallbackContext context);
    }
}
