using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace InventorySystem
{
	public class ItemFactory : Singleton<ItemFactory>
	{
		[SerializeField] private Item itemPrefab;
		private ItemData[] Items => GlobalData.GameData.itemsInformation;
		private Dictionary<int, int> chanceMapping = new Dictionary<int, int>();

		private void Start()
		{
			FillChanceMapping();
		}

		public Item GetRandomItem(float dropChance)
		{
			var isDropped = Random.Range(0, 1f) <= dropChance;
			if (!isDropped)
				return null;

			var randomItemChance = Random.Range(0, chanceMapping.Count);
			if (chanceMapping.TryGetValue(randomItemChance, out var itemIndex))
				return Instantiate(itemPrefab).SetData(Items[itemIndex]);
			
			Debug.LogWarning("randomItemChance is not found!");
			return null;
		}

		private void FillChanceMapping()
		{
			var cnt = 0;
			chanceMapping = new Dictionary<int, int>();
			for (var i = 0; i < Items.Length; i++)
			for (var j = 0; j < Items[i].dropChanceWeight; j++)
				chanceMapping.Add(cnt++, i);
		}
	}
}