using Data;
using Player;
using UnityEngine;

namespace Objects
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class Item: MonoBehaviour, ICollisionTarget
	{
		public ItemData ItemData => data;
		[SerializeField] private ItemData data;

		private bool isActivated;
		private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

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

		public Item SetData(ItemData itemData)
		{
			data = itemData;
			spriteRenderer.sprite = itemData.sprite;
			return this;
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