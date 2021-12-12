using System;
using System.Collections;
using Data;
using DG.Tweening;
using Enemies;
using Interfaces;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace Player
{
	[RequireComponent(typeof(Player))]
	[RequireComponent(typeof(CharacterController))]
	public class PlayerController : MonoBehaviour
	{
		public static Action<float> OnDash;
		
		[SerializeField] private Camera playerCamera;
		[SerializeField] private GameObject katana;
		[SerializeField] private AnimationData primaryAttackAnimationData;
		[SerializeField] private AnimationData secondaryAttackAnimationData;

		private Player player;
		private PlayerInputActions inputActions;
		private CharacterController characterController;
		private Animator animator;
		private Coroutine jumpCoroutine;
		private int jumpsPerformed;
		private bool isJumping;
		private bool isSprinting;
		private bool isAttacking;
		private bool canDash = true;

		private PlayerStats Stats => player.playerStats;
		private float MouseSensitivity => Stats.MouseSensitivity;
		private float MaxYRotation => Stats.MaxYRotation;
		private float MinYRotation => Stats.MinYRotation;
		private float InteractionDistance => Stats.InteractionDistance;
		private bool CanJump => jumpsPerformed < Stats.MaxJumps && Player.IsControllable;

		private void Awake()
		{
			animator = GetComponent<Animator>();
			characterController = GetComponent<CharacterController>();
			player = GetComponent<Player>();
		}

		private void Start()
		{
			katana.SetActive(false);
			inputActions = player.InputActions;
			inputActions.Controls.PrimaryAttack.performed += PrimaryAttack;
			inputActions.Controls.SecondaryAttack.performed += SecondaryAttack;
			inputActions.Controls.Sprint.performed += ToggleSprint;
			inputActions.Controls.Dash.performed += Dash;
			inputActions.Controls.Jump.started += StartJump;
			inputActions.Controls.Jump.canceled += EndJump;
			inputActions.Controls.Interact.performed += Interact;
			inputActions.UI.GameMenu.performed += context => GameMenu.ToggleInstance();
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
		}

		private void Update()
		{
			if (!Player.IsControllable)
				return;
			
			Move();
			RotateCamera();
			TryResetJumpCounter();
		}

		private void OnTriggerEnter(Collider other)
		{
			if(isAttacking)
				other.GetComponent<Enemy>()?.ReceiveDamage(Stats.Damage);
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
			if (!canDash || !Player.IsControllable)
				return;
			characterController.Move(transform.forward * Stats.DashDistance);
			canDash = false;
			OnDash?.Invoke(Stats.DashCooldown);
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
			while (tr.position.y < targetHeight && Player.IsControllable)
			{
				yield return step;
				characterController.Move(Vector3.up * (Stats.JumpHeight * Time.deltaTime));
			}

			isJumping = false;
		}

		private void TryResetJumpCounter()
		{
			if (characterController.isGrounded)
				jumpsPerformed = 0;
		}

		private void Interact(InputAction.CallbackContext context)
		{
			var tr = playerCamera.transform;
			var raycastResults = Physics.RaycastAll(tr.position, tr.forward, InteractionDistance);
			foreach (var raycastResult in raycastResults)
			{
				raycastResult.transform.GetComponent<IInteractable>()?.OnInteract();
			}
		}

		private void PrimaryAttack(InputAction.CallbackContext context)
		{
			PerformAttack(primaryAttackAnimationData);
		}

		private void SecondaryAttack(InputAction.CallbackContext context)
		{
			PerformAttack(secondaryAttackAnimationData);
		}

		private void PerformAttack(AnimationData animationData)
		{
			if (isAttacking)
				return;

			katana.SetActive(true);
			isAttacking = true;
			animator.SetTrigger(animationData.TriggerHash);
			DOVirtual.DelayedCall(animationData.Duration, () =>
			{
				isAttacking = false;
				katana.SetActive(false);
			});
		}

		private void OnDrawGizmos()
		{
			var tr = playerCamera.transform;
			Gizmos.color = Color.green;
			if (Application.isPlaying)
			{
				Gizmos.DrawRay(tr.position, tr.forward * InteractionDistance);
			}
		}
	}
}