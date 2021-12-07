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

		private void UpdateStats(ItemData item, bool isPositive)
		{
			var sign = isPositive ? 1 : -1;
			maxHealth += item.healthBoost * sign;
			damage += item.damageBoost * sign;
			attackSpeed += item.attackSpeedBoost * sign;
			movementSpeed += item.movementSpeedBoost * sign;
			criticalChance += item.criticalChanceBoost * sign;
			criticalMultiplier += item.criticalMultiplierBoost * sign;
			sprintSpeedMultiplier += item.sprintSpeedMultiplierBoost * sign;
			dashDistance += item.dashDistanceBoost * sign;
			dashCooldown -= item.dashCooldownBoost * sign;
			jumpHeight += item.jumpHeightBoost * sign;
			maxJumps += item.maxJumpsBoost;
		}
	}
}