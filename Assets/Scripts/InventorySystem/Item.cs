using Data;
using Player;
using UnityEngine;

namespace InventorySystem
{
	public class Item: MonoBehaviour, ICollisionTarget
	{
		[SerializeField] private ItemData data;

		private bool isActivated;

		public void OnCollision(GameObject other)
		{
			if(isActivated)
				return;
			
			var playerInventory = other.GetComponent<PlayerInventory>();
			if (playerInventory == null)
				return;
			
			playerInventory.AddItems(data);
			isActivated = true;
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

		public bool Equals(Item other)
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