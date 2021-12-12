using System;
using Events;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Player
{
	public class Player : MonoBehaviour, IEntity
	{
		public static Action<float> OnPlayerHPUpdated;
		public static bool IsControllable = true;
		public PlayerInputActions InputActions { get; private set; }
		public PlayerStats playerStats = new PlayerStats();
		public float Health => health;
		private float health;

		private void Awake()
		{
			InputActions = new PlayerInputActions();
			health = playerStats.MaxHealth;
			playerStats.SetPlayer(this);
			GameBus.OnGameCompleted += CommitDie;
			GameBus.OnGameOver += CommitDie;
			IsControllable = true;
		}

		private void OnEnable()
		{
			InputActions.Enable();
		}

		private void OnDisable()
		{
			InputActions.Disable();
		}

		private void OnDestroy()
		{
			GameBus.OnGameCompleted -= CommitDie;
			GameBus.OnGameOver -= CommitDie;
		}
		
		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			hit.gameObject.GetComponent<ICollisionTarget>()?.OnCollision(gameObject);
		}

		public void ReceiveDamage(float amount)
		{
			health -= amount;
			Debug.Log($"Player health: {health}");
			OnPlayerHPUpdated?.Invoke(health / playerStats.MaxHealth);
			if(health <= 0)
				Die();
		}

		public void ReceiveHeal(float amount)
		{
			health += amount;
			health = Mathf.Min(health, playerStats.MaxHealth);
			OnPlayerHPUpdated?.Invoke(health / playerStats.MaxHealth);
			Debug.Log($"Player health: {health}");
		}

		private void Die()
		{
			GameBus.OnGameOver?.Invoke();
			Debug.Log("Смерть пришла незаметно...");
			CommitDie();
		}

		private void CommitDie()
		{
			IsControllable = false;
		}
	}
}