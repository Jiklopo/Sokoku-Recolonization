using System;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class ItemData
	{
		public Sprite icon;
		public bool isUsable;
		public int maxStack;
		public string name;

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			if (ReferenceEquals(obj, null)) return false;
			if (obj.GetType() != typeof(ItemData)) return false;

			var other = (ItemData) obj;
			return Equals(other);
		}

		protected bool Equals(ItemData other)
		{
			return name.Equals(other.name);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = isUsable.GetHashCode();
				hashCode = (hashCode * 397) ^ maxStack;
				hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}