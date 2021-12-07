using Events;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Player
{
	public class Player : Singleton<Player>, IEntity
	{
		public PlayerInputActions InputActions { get; private set; }
		public PlayerStats playerStats = new PlayerStats();
		public float Health => health;
		private float health;

		protected override void Awake()
		{
			base.Awake();
			InputActions = new PlayerInputActions();
			health = playerStats.MaxHealth;
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

		public void ReceiveDamage(float amount)
		{
			health -= amount;
			Debug.Log($"Player health: {health}");
			if(health <= 0)
				Die();
		}

		public void ReceiveHeal(float amount)
		{
			health += amount;
			health = Mathf.Min(health, playerStats.MaxHealth);
			Debug.Log($"Player health: {health}");
		}

		private void Die()
		{
			GameBus.OnGameOver.Invoke();
			Debug.Log("Смерть пришла незаметно...");
			Destroy(gameObject);
		}
	}
}