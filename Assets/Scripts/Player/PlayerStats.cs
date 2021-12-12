using System;
using Data;
using UnityEngine;

namespace Player
{
	[Serializable]
	public class PlayerStats
	{
		#region Public Properties

		public float MaxHealth => maxHealth;
		public float Damage => damage;
		public float AttackSpeed => attackSpeed;
		public float MovementSpeed => movementSpeed;
		public float SprintSpeedMultiplier => sprintSpeedMultiplier;
		public float DashDistance => dashDistance;
		public float DashCooldown => dashCooldown;
		public float CriticalChance => criticalChance;
		public float CriticalMultiplier => criticalMultiplier;
		public float JumpHeight => jumpHeight;
		public int MaxJumps => maxJumps;
		public float MouseSensitivity => mouseSensitivity;
		public float MaxYRotation => maxYRotation;
		public float MinYRotation => minYRotation;
		public float InteractionDistance => interactionDistance;

		#endregion


		[Header("Game Stats")]
		[SerializeField] private float maxHealth = 100;
		[SerializeField] private float damage = 10;
		[SerializeField] private float attackSpeed = 10;
		[SerializeField] private float movementSpeed = 10;
		[SerializeField] private float sprintSpeedMultiplier = 1.25f;
		[SerializeField] private float dashDistance = 10f;
		[SerializeField] private float dashCooldown = 5f;
		[SerializeField] private float criticalChance = 10;
		[SerializeField] private float criticalMultiplier = 10;
		[SerializeField] private float jumpHeight = 10;
		[SerializeField] private int maxJumps = 2;

		[Header("Player Controller")] 
		[SerializeField] private float mouseSensitivity = 10;
		[SerializeField] private float maxYRotation = 360;
		[SerializeField] private float minYRotation = -90;
		[SerializeField] private float interactionDistance = 5;

		private Player player;

		public void BoostStats(ItemData item, int amount)
		{
			for (var i = 0; i < amount; i++)
				UpdateStats(item, true);
		}

		public void RemoveStats(ItemData item, int amount)
		{
			for (var i = 0; i < amount; i++)
				UpdateStats(item, false);
		}

		public void SetPlayer(Player player)
		{
			this.player = player;
		}

		private void UpdateStats(ItemData item, bool isPositive)
		{
			var sign = isPositive ? 1 : -1;
			maxHealth += item.HealthBoost * sign;
			damage += item.DamageBoost * sign;
			attackSpeed += item.AttackSpeedBoost * sign;
			movementSpeed += item.MovementSpeedBoost * sign;
			criticalChance += item.CriticalChanceBoost * sign;
			criticalMultiplier += item.CriticalMultiplierBoost * sign;
			sprintSpeedMultiplier += item.SprintSpeedMultiplierBoost * sign;
			dashDistance += item.DashDistanceBoost * sign;
			dashCooldown -= item.DashCooldownBoost * sign;
			jumpHeight += item.JumpHeightBoost * sign;
			maxJumps += item.MaxJumpsBoost;

			if (isPositive)
			{
				player.ReceiveHeal(item.HealthBoost);
			}
		}
	}
}