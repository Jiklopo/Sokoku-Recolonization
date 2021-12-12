using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace InventorySystem
{
	public abstract class Factory<TProduct, TSingleton>: Singleton<TSingleton> 
		where TProduct: Object, IFactoryProduct 
		where TSingleton : Component
	{
		[SerializeField] protected TProduct[] objectsList;

		public bool IsInitialized { get; protected set; }
		private Dictionary<int, int> chanceMapping = new Dictionary<int, int>();

		protected virtual void Start()
		{
			FillChanceMapping();
		}

		public TProduct GetRandomObject()
		{
			var randomItemChance = Random.Range(0, chanceMapping.Count);
			if (chanceMapping.TryGetValue(randomItemChance, out var itemIndex))
				return InstantiateItem(itemIndex);
			
			Debug.LogWarning("No item is found!", this);
			return null;
		}

		private void FillChanceMapping()
		{
			var cnt = 0;
			chanceMapping = new Dictionary<int, int>();
			for (var i = 0; i < objectsList.Length; i++)
			{
				for (var j = 0; j < objectsList[i].DropChanceWeight; j++)
					chanceMapping.Add(cnt++, i);
			}

			IsInitialized = true;
		}

		protected abstract TProduct InstantiateItem(int selectedItemIndex);
	}
}