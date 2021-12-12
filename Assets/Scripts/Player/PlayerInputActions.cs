// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""e5938b43-6070-482d-b30e-e38d8cc5fe3e"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Value"",
                    ""id"": ""d4f80677-9990-4ba7-94ba-5b7ecf4c34a9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Value"",
                    ""id"": ""97a1bfac-f141-45a7-84da-d269add57a48"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PointerDelta"",
                    ""type"": ""Value"",
                    ""id"": ""fc8829e0-3198-4922-b1f2-eae4b6666e7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""W/S"",
                    ""id"": ""25d7f5eb-91de-485c-82d6-d6669b2b3ec6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c88b0e9c-d855-4d6a-9af8-ec365846e3d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""53bd6a69-8bd2-424c-9424-2bf1b39589f3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""3a785904-869d-4aba-91d4-cd42269a4258"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""904af5bd-e542-4c49-b2f2-33598b8e09e2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""df1fe71b-c88f-4381-86c4-a0f1639ee185"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""A/D"",
                    ""id"": ""26e784b3-98e5-4bb2-9284-92cdff3d2656"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d9bf3300-6b2f-4cf5-94f9-71a2e41d6fc3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fc33a034-9358-4626-b4ab-f21e2e63008c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""55e506ec-762a-4c46-b4d0-6599523463bc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""94a01127-fb3a-4b3f-876a-4fb38dedc514"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c8efe5ab-f3d1-40d6-a02c-b18c4d56f5a0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f76fd58a-7df7-4252-b053-b34561ae962a"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Controls"",
            ""id"": ""113649f9-96f9-4383-b08f-21ea46f8a3ca"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fc29686e-f191-4509-9879-81a350357308"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7b2d9587-081c-443c-ad91-6bab68eff39a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""738fab7c-3361-4b4a-a05c-b5fed4677a1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""68d5c791-734c-4d70-b5a3-2e90060ad153"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""b1955eb6-e19d-4dfc-b39c-963b372343a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""f20558e9-6651-4fe1-bde1-23c264830fb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e3ac54e3-db19-417a-b0eb-0e186108db9a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""baae2ba1-6963-4932-81e7-7c4b1fe52cb1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""790ef5f1-9ca6-43ea-b5df-c5c1923c2f34"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6edb5294-50e1-4a3e-8b8f-7e84f95d8052"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da7bb333-b38a-4b38-9a70-338142740fec"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48db9aeb-2b5c-49e7-9402-77ea1cce5a8b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""e6615871-54dd-4252-9aed-35e0a3c3e775"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""7ac7a23e-bf35-43ad-b9db-5a2ed1ed1081"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GameMenu"",
                    ""type"": ""Button"",
                    ""id"": ""1c1fe0d9-21ad-47fe-99ab-fb0ddcc91d31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5ff5fdc-d350-4034-926f-cebb0d2364bf"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47852ccf-019a-45ae-a6c2-6c22394168bf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GameMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movement
            m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
            m_Movement_Forward = m_Movement.FindAction("Forward", throwIfNotFound: true);
            m_Movement_Right = m_Movement.FindAction("Right", throwIfNotFound: true);
            m_Movement_PointerDelta = m_Movement.FindAction("PointerDelta", throwIfNotFound: true);
            // Controls
            m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
            m_Controls_Jump = m_Controls.FindAction("Jump", throwIfNotFound: true);
            m_Controls_Interact = m_Controls.FindAction("Interact", throwIfNotFound: true);
            m_Controls_PrimaryAttack = m_Controls.FindAction("PrimaryAttack", throwIfNotFound: true);
            m_Controls_SecondaryAttack = m_Controls.FindAction("SecondaryAttack", throwIfNotFound: true);
            m_Controls_Sprint = m_Controls.FindAction("Sprint", throwIfNotFound: true);
            m_Controls_Dash = m_Controls.FindAction("Dash", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Inventory = m_UI.FindAction("Inventory", throwIfNotFound: true);
            m_UI_GameMenu = m_UI.FindAction("GameMenu", throwIfNotFound: true);
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

        // Movement
        private readonly InputActionMap m_Movement;
        private IMovementActions m_MovementActionsCallbackInterface;
        private readonly InputAction m_Movement_Forward;
        private readonly InputAction m_Movement_Right;
        private readonly InputAction m_Movement_PointerDelta;
        public struct MovementActions
        {
            private @PlayerInputActions m_Wrapper;
            public MovementActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Forward => m_Wrapper.m_Movement_Forward;
            public InputAction @Right => m_Wrapper.m_Movement_Right;
            public InputAction @PointerDelta => m_Wrapper.m_Movement_PointerDelta;
            public InputActionMap Get() { return m_Wrapper.m_Movement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
            public void SetCallbacks(IMovementActions instance)
            {
                if (m_Wrapper.m_MovementActionsCallbackInterface != null)
                {
                    @Forward.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                    @Forward.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                    @Forward.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnForward;
                    @Right.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRight;
                    @PointerDelta.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerDelta;
                    @PointerDelta.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerDelta;
                    @PointerDelta.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnPointerDelta;
                }
                m_Wrapper.m_MovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Forward.started += instance.OnForward;
                    @Forward.performed += instance.OnForward;
                    @Forward.canceled += instance.OnForward;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @PointerDelta.started += instance.OnPointerDelta;
                    @PointerDelta.performed += instance.OnPointerDelta;
                    @PointerDelta.canceled += instance.OnPointerDelta;
                }
            }
        }
        public MovementActions @Movement => new MovementActions(this);

        // Controls
        private readonly InputActionMap m_Controls;
        private IControlsActions m_ControlsActionsCallbackInterface;
        private readonly InputAction m_Controls_Jump;
        private readonly InputAction m_Controls_Interact;
        private readonly InputAction m_Controls_PrimaryAttack;
        private readonly InputAction m_Controls_SecondaryAttack;
        private readonly InputAction m_Controls_Sprint;
        private readonly InputAction m_Controls_Dash;
        public struct ControlsActions
        {
            private @PlayerInputActions m_Wrapper;
            public ControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_Controls_Jump;
            public InputAction @Interact => m_Wrapper.m_Controls_Interact;
            public InputAction @PrimaryAttack => m_Wrapper.m_Controls_PrimaryAttack;
            public InputAction @SecondaryAttack => m_Wrapper.m_Controls_SecondaryAttack;
            public InputAction @Sprint => m_Wrapper.m_Controls_Sprint;
            public InputAction @Dash => m_Wrapper.m_Controls_Dash;
            public InputActionMap Get() { return m_Wrapper.m_Controls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
            public void SetCallbacks(IControlsActions instance)
            {
                if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                    @Interact.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                    @PrimaryAttack.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPrimaryAttack;
                    @PrimaryAttack.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPrimaryAttack;
                    @PrimaryAttack.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPrimaryAttack;
                    @SecondaryAttack.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSecondaryAttack;
                    @SecondaryAttack.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSecondaryAttack;
                    @SecondaryAttack.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSecondaryAttack;
                    @Sprint.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                    @Dash.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDash;
                }
                m_Wrapper.m_ControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @PrimaryAttack.started += instance.OnPrimaryAttack;
                    @PrimaryAttack.performed += instance.OnPrimaryAttack;
                    @PrimaryAttack.canceled += instance.OnPrimaryAttack;
                    @SecondaryAttack.started += instance.OnSecondaryAttack;
                    @SecondaryAttack.performed += instance.OnSecondaryAttack;
                    @SecondaryAttack.canceled += instance.OnSecondaryAttack;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                }
            }
        }
        public ControlsActions @Controls => new ControlsActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Inventory;
        private readonly InputAction m_UI_GameMenu;
        public struct UIActions
        {
            private @PlayerInputActions m_Wrapper;
            public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Inventory => m_Wrapper.m_UI_Inventory;
            public InputAction @GameMenu => m_Wrapper.m_UI_GameMenu;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Inventory.started -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                    @Inventory.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                    @Inventory.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                    @GameMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnGameMenu;
                    @GameMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnGameMenu;
                    @GameMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnGameMenu;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Inventory.started += instance.OnInventory;
                    @Inventory.performed += instance.OnInventory;
                    @Inventory.canceled += instance.OnInventory;
                    @GameMenu.started += instance.OnGameMenu;
                    @GameMenu.performed += instance.OnGameMenu;
                    @GameMenu.canceled += instance.OnGameMenu;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        public interface IMovementActions
        {
            void OnForward(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnPointerDelta(InputAction.CallbackContext context);
        }
        public interface IControlsActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnPrimaryAttack(InputAction.CallbackContext context);
            void OnSecondaryAttack(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnInventory(InputAction.CallbackContext context);
            void OnGameMenu(InputAction.CallbackContext context);
        }
    }
}
