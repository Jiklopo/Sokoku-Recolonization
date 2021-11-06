using System;
using Data;
using UnityEngine;

namespace InventorySystem
{
	[Serializable]
	public abstract class Item
	{
		[SerializeField] protected Sprite icon;
		public abstract bool IsUsable { get; }
		public abstract int MaxStack { get; }
		public abstract string Name { get; }

		public virtual void Use(ItemUseData itemUseData)
		{
			
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			if (ReferenceEquals(obj, null)) return false;
			if (obj.GetType() != typeof(Item)) return false;

			var other = (Item) obj;
			return Equals(other);
		}

		protected bool Equals(Item other)
		{
			return Name.Equals(other.Name);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = icon != null ? icon.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ IsUsable.GetHashCode();
				hashCode = (hashCode * 397) ^ MaxStack;
				hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}