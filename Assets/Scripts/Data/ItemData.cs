using System;
using UnityEngine;

namespace Data
{
	[Serializable]
	[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/Item Data", order = 1)]
	public class ItemData : ScriptableObject
	{
		#region Public Properties

		public Sprite Sprite => sprite;
		public string Name => name;
		public string Description => description;
		public int DropChanceWeight => dropChanceWeight;
		public int HealthBoost => healthBoost;
		public int DamageBoost => damageBoost;
		public float AttackSpeedBoost => attackSpeedBoost;
		public float MovementSpeedBoost => movementSpeedBoost;
		public float SprintSpeedMultiplierBoost => sprintSpeedMultiplierBoost;
		public float DashDistanceBoost => dashDistanceBoost;
		public float DashCooldownBoost => dashCooldownBoost;
		public float CriticalChanceBoost => criticalChanceBoost;
		public float CriticalMultiplierBoost => criticalMultiplierBoost;
		public float JumpHeightBoost => jumpHeightBoost;
		public int MaxJumpsBoost => maxJumpsBoost;

		#endregion
		#region Serializable fields

		[Header("Game Data")] 
		[SerializeField] private Sprite sprite;
		[SerializeField] private string name;
		[SerializeField] private string description;
		[SerializeField] private int dropChanceWeight;

		[Header("Stats Boost")] 
		[SerializeField] private int healthBoost;
		[SerializeField] private int damageBoost;
		[SerializeField] private float attackSpeedBoost;
		[SerializeField] private float movementSpeedBoost;
		[SerializeField] private float sprintSpeedMultiplierBoost;
		[SerializeField] private float dashDistanceBoost;
		[SerializeField] private float dashCooldownBoost;
		[SerializeField] private float criticalChanceBoost;
		[SerializeField] private float criticalMultiplierBoost;
		[SerializeField] private float jumpHeightBoost;
		[SerializeField] private int maxJumpsBoost;

		#endregion


		public bool Equals(ItemData other)
		{
			return name.Equals(other.name);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			if (ReferenceEquals(obj, null)) return false;
			if (obj.GetType() != typeof(ItemData)) return false;

			var other = (ItemData) obj;
			return Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (name != null ? name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ healthBoost;
				hashCode = (hashCode * 397) ^ damageBoost;
				hashCode = (hashCode * 397) ^ attackSpeedBoost.GetHashCode();
				hashCode = (hashCode * 397) ^ movementSpeedBoost.GetHashCode();
				hashCode = (hashCode * 397) ^ criticalChanceBoost.GetHashCode();
				hashCode = (hashCode * 397) ^ criticalMultiplierBoost.GetHashCode();
				return hashCode;
			}
		}
	}
}