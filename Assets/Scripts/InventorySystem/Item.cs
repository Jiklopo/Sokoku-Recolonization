using System;
using Data;
using Player;
using UnityEngine;

namespace InventorySystem
{
	public abstract class Item: MonoBehaviour, ICollisionTarget
	{
		[SerializeField] private ItemData data;

		public virtual void Use(ItemUseData itemUseData)
		{
		}

		public virtual void OnCollision(GameObject other)
		{
			var playerInventory = other.GetComponent<PlayerInventory>();
			if (playerInventory == null)
				return;
			if(playerInventory.AddItems(data))
				Destroy(gameObject);
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
			return data.Equals(other.data);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = 397 ^ data.GetHashCode();
				return hashCode;
			}
		}
	}
}