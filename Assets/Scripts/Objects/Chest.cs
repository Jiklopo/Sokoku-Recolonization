using Factories;
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

			var item = ItemFactory.Instance.SpawnRandomItem(1, transform);
			if (item == null)
				return;

			item.transform.Translate(itemOffset);
			isUsed = true;
		}
	}
}