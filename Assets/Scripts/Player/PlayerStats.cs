using System;
using Data;
using UnityEngine;

namespace Player
{
	[Serializable]
	public class PlayerStats
	{
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
		public int MaxJumpAmount => maxJumpAmount;

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
		[SerializeField] private int maxJumpAmount = 2;

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
		}
	}
}