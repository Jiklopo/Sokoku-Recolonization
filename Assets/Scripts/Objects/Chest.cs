using UnityEngine;

namespace InventorySystem
{
	public class Chest : MonoBehaviour, ICollisionTarget
	{
		[SerializeField] private Vector3 itemOffset;

		private bool isUsed;
		public void OnCollision(GameObject other)
		{
			if (isUsed)
				return;

			var item = ItemFactory.Instance.GetRandomItem(1);
			if (item == null)
				return;
			
			item.transform.position = transform.position + Vector3.up;
			isUsed = true;
		}
	}
}