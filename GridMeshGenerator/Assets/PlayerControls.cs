// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Preview"",
            ""id"": ""cddb6a1c-4d7c-4460-a8a5-03809f799f39"",
            ""actions"": [
                {
                    ""name"": ""CursorPosition"",
                    ""type"": ""Value"",
                    ""id"": ""39ac0ab1-2fdd-4449-a56b-3b7849221f5b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""20568277-7e16-4138-bf12-2f4b54240568"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""374bd528-2258-4756-8855-de059dede814"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""530aa32a-634d-4a22-8e98-f5d9503a7d28"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Preview
        m_Preview = asset.FindActionMap("Preview", throwIfNotFound: true);
        m_Preview_CursorPosition = m_Preview.FindAction("CursorPosition", throwIfNotFound: true);
        m_Preview_Select = m_Preview.FindAction("Select", throwIfNotFound: true);
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

    // Preview
    private readonly InputActionMap m_Preview;
    private IPreviewActions m_PreviewActionsCallbackInterface;
    private readonly InputAction m_Preview_CursorPosition;
    private readonly InputAction m_Preview_Select;
    public struct PreviewActions
    {
        private @PlayerControls m_Wrapper;
        public PreviewActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CursorPosition => m_Wrapper.m_Preview_CursorPosition;
        public InputAction @Select => m_Wrapper.m_Preview_Select;
        public InputActionMap Get() { return m_Wrapper.m_Preview; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PreviewActions set) { return set.Get(); }
        public void SetCallbacks(IPreviewActions instance)
        {
            if (m_Wrapper.m_PreviewActionsCallbackInterface != null)
            {
                @CursorPosition.started -= m_Wrapper.m_PreviewActionsCallbackInterface.OnCursorPosition;
                @CursorPosition.performed -= m_Wrapper.m_PreviewActionsCallbackInterface.OnCursorPosition;
                @CursorPosition.canceled -= m_Wrapper.m_PreviewActionsCallbackInterface.OnCursorPosition;
                @Select.started -= m_Wrapper.m_PreviewActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PreviewActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PreviewActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_PreviewActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CursorPosition.started += instance.OnCursorPosition;
                @CursorPosition.performed += instance.OnCursorPosition;
                @CursorPosition.canceled += instance.OnCursorPosition;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public PreviewActions @Preview => new PreviewActions(this);
    public interface IPreviewActions
    {
        void OnCursorPosition(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
