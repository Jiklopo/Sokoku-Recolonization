using Interfaces;
using InventorySystem;
using UnityEngine;

namespace Objects
{
	public class Chest : MonoBehaviour, IInteractable
	{
		[SerializeField] private Vector3 itemOffset;

		private bool isUsed;
		public void OnInteract()
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