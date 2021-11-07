using System;
using UnityEngine;

namespace Player
{
	public class Player : MonoBehaviour
	{
		public PlayerInputActions InputActions { get; private set; }

		private void Awake()
		{
			InputActions = new PlayerInputActions();
		}

		private void OnEnable()
		{
			InputActions.Enable();
		}

		private void OnDisable()
		{
			InputActions.Disable();
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			hit.gameObject.GetComponent<ICollisionTarget>()?.OnCollision(gameObject);
		}
	}
}