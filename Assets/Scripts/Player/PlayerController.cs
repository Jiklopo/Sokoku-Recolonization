using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	[RequireComponent(typeof(Player))]
	[RequireComponent(typeof(CharacterController))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Camera playerCamera;

		private Player player;
		private PlayerInputActions inputActions;
		private CharacterController characterController;
		private Coroutine jumpCoroutine;
		private int jumpsPerformed;
		private bool isJumping;
		private bool isSprinting;
		private bool canDash = true;

		private PlayerStats Stats => player.playerStats;
		private float MouseSensitivity => Stats.MouseSensitivity;
		private float MaxYRotation => Stats.MaxYRotation;
		private float MinYRotation => Stats.MinYRotation;
		private float InteractionDistance => Stats.InteractionDistance;
		private bool CanJump => jumpsPerformed < Stats.MaxJumps;

		private void Awake()
		{
			characterController = GetComponent<CharacterController>();
			player = GetComponent<Player>();
		}

		private void Start()
		{
			inputActions = player.InputActions;
			inputActions.Controls.PrimaryAttack.performed += PrimaryAttack;
			inputActions.Controls.SecondaryAttack.performed += SecondaryAttack;
			inputActions.Controls.Sprint.performed += ToggleSprint;
			inputActions.Controls.Dash.performed += Dash;
			inputActions.Controls.Jump.started += StartJump;
			inputActions.Controls.Jump.canceled += EndJump;
			inputActions.Controls.Interact.performed += Interact;
		}

		private void Update()
		{
			Move();
			RotateCamera();
			TryResetJumpCounter();
		}

		private void OnDestroy()
		{
			inputActions.Controls.PrimaryAttack.performed -= PrimaryAttack;
			inputActions.Controls.SecondaryAttack.performed -= SecondaryAttack;
			inputActions.Controls.Interact.performed -= Interact;
			inputActions.Controls.Jump.performed -= StartJump;
		}

		private void Move()
		{
			var forward = inputActions.Movement.Forward.ReadValue<float>();
			var right = inputActions.Movement.Right.ReadValue<float>();
			var direction = new Vector3(right, 0, forward);

			direction = transform.TransformDirection(direction) * (Stats.MovementSpeed * Time.deltaTime);
			if (direction == Vector3.zero)
				isSprinting = false;
			if (isSprinting)
				direction *= Stats.SprintSpeedMultiplier;
			if (!isJumping)
				characterController.SimpleMove(Vector3.zero);
			characterController.Move(direction);
		}

		private void RotateCamera()
		{
			var pointerDelta = inputActions.Movement.PointerDelta.ReadValue<Vector2>();
			transform.Rotate(Vector3.up * (MouseSensitivity * pointerDelta.x * Time.deltaTime));

			var cameraTransform = playerCamera.transform;
			var cameraRotation = pointerDelta.y * MouseSensitivity * Time.deltaTime;
			cameraRotation = Mathf.Clamp(cameraTransform.localRotation.eulerAngles.x - cameraRotation, MinYRotation,
				MaxYRotation);
			cameraTransform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);
		}

		private void ToggleSprint(InputAction.CallbackContext context)
		{
			isSprinting = !isSprinting;
		}

		private void Dash(InputAction.CallbackContext context)
		{
			if (!canDash)
				return;
			characterController.Move(transform.forward * Stats.DashDistance);
			canDash = false;
			StartCoroutine(ResetDashRoutine());
		}

		private IEnumerator ResetDashRoutine()
		{
			yield return new WaitForSeconds(Stats.DashCooldown);
			canDash = true;
		}

		private void StartJump(InputAction.CallbackContext context)
		{
			if (!CanJump)
				return;

			jumpCoroutine = StartCoroutine(JumpCoroutine());
		}

		private void EndJump(InputAction.CallbackContext context)
		{
			StopCoroutine(jumpCoroutine);
			isJumping = false;
			jumpsPerformed++;
		}

		private IEnumerator JumpCoroutine()
		{
			isJumping = true;
			var tr = transform;
			var step = new WaitForEndOfFrame();
			var targetHeight = tr.position.y + Stats.JumpHeight;
			while (tr.position.y < targetHeight)
			{
				yield return step;
				characterController.Move(Vector3.up * (Stats.JumpHeight * Time.deltaTime));
			}
		}

		private void TryResetJumpCounter()
		{
			if (characterController.isGrounded)
				jumpsPerformed = 0;
		}

		private void Interact(InputAction.CallbackContext context)
		{
			var tr = transform;
			var raycastResults = Physics.RaycastAll(tr.position, tr.forward, InteractionDistance);
			foreach (var raycastResult in raycastResults)
			{
				raycastResult.transform.GetComponent<IInteractable>()?.OnInteract();
			}
		}

		private void SecondaryAttack(InputAction.CallbackContext context)
		{
			throw new System.NotImplementedException();
		}

		private void PrimaryAttack(InputAction.CallbackContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}