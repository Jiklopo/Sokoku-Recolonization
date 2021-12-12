using Data;
using InventorySystem;
using Objects;
using UnityEngine;

namespace Factories
{
	public class ItemFactory : Factory<ItemData, ItemFactory>
	{
		[SerializeField] private Item itemPrefab;

		protected override void Start()
		{
			objectsList = GlobalData.Items;
			base.Start();
		}

		public Item SpawnRandomItem(float dropChance, Transform parent = null)
		{
			var isDropped = Random.Range(0, 1f) <= dropChance;
			if (!isDropped)
				return null;

			return Instantiate(itemPrefab, parent)
				.SetData(GetRandomObject());
		}
		
		protected override ItemData InstantiateItem(int selectedItemIndex)
		{
			return objectsList[selectedItemIndex];
		}
	}
}