using UnityEngine;
using Utilities;

namespace Player
{
	public class Player : Singleton<Player>
	{
		public PlayerInputActions InputActions { get; private set; }
		public PlayerStats playerStats = new PlayerStats();

		protected override void Awake()
		{
			base.Awake();
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