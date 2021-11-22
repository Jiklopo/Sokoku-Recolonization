using System;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class ItemData
	{
		[Header("Item Data")]
		public Sprite icon;
		public string name;

		[Header("Stats Boost")] 
		public int healthBoost;
		public int damageBoost;
		public float attackSpeedBoost;
		public float movementSpeedBoost;
		public float criticalChanceBoost;
		public float criticalMultiplierBoost;

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