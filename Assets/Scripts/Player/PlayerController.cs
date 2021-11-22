using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	[RequireComponent(typeof(Player))]
	[RequireComponent(typeof(CharacterController))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Camera playerCamera;
		[SerializeField] private float mouseSensitivity;
		[SerializeField] private float maxYRotation = 360;
		[SerializeField] private float minYRotation = -90;

		private Player player;
		private PlayerInputActions inputActions;
		private CharacterController characterController;

		private PlayerStats Stats => player.playerStats;

		private void Awake()
		{
			characterController = GetComponent<CharacterController>();
			player = GetComponent<Player>();
			
		}

		private void Start()
		{
			inputActions = player.InputActions;
			inputActions.Controls.Action1.performed += Action1;
			inputActions.Controls.Action2.performed += Action2;
			inputActions.Controls.Interact.performed += Interact;
			inputActions.Controls.Jump.performed += Jump;
		}

		private void Update()
		{
			Move();
			RotateCamera();
		}

		private void OnDestroy()
		{
			inputActions.Controls.Action1.performed -= Action1;
			inputActions.Controls.Action2.performed -= Action2;
			inputActions.Controls.Interact.performed -= Interact;
			inputActions.Controls.Jump.performed -= Jump;
		}

		private void Move()
		{
			var forward = inputActions.Movement.Forward.ReadValue<float>();
			var right = inputActions.Movement.Right.ReadValue<float>();
			var direction = new Vector3(right, 0, forward);
			
			direction = transform.TransformDirection(direction);
			characterController.Move(direction * (Stats.MovementSpeed * Time.deltaTime));
		}

		private void RotateCamera()
		{
			var pointerDelta = inputActions.Movement.PointerDelta.ReadValue<Vector2>();
			transform.Rotate(Vector3.up * (mouseSensitivity * pointerDelta.x * Time.deltaTime));

			var cameraTransform = playerCamera.transform;
			var cameraRotation = pointerDelta.y * mouseSensitivity * Time.deltaTime;
			cameraRotation = Mathf.Clamp(cameraTransform.localRotation.eulerAngles.x - cameraRotation, minYRotation, maxYRotation);
			cameraTransform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);
		}

		private void Jump(InputAction.CallbackContext context)
		{
			throw new System.NotImplementedException();
		}

		private void Interact(InputAction.CallbackContext context)
		{
			throw new System.NotImplementedException();
		}

		private void Action2(InputAction.CallbackContext context)
		{
			throw new System.NotImplementedException();
		}

		private void Action1(InputAction.CallbackContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}