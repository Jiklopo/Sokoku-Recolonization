using System;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class ItemData
	{
		[Header("Game Data")]
		public Sprite sprite;
		public string name;
		public int dropChanceWeight;

		[Header("Stats Boost")] 
		public int healthBoost;
		public int damageBoost;
		public float attackSpeedBoost;
		public float movementSpeedBoost;
		public float sprintSpeedMultiplierBoost;
		public float dashDistanceBoost;
		public float dashCooldownBoost;
		public float criticalChanceBoost;
		public float criticalMultiplierBoost;
		public float jumpHeightBoost;
		public int maxJumpsBoost;

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