using UnityEngine;
using Utilities;

namespace Data
{
	public class GlobalData : Singleton<GlobalData>
	{
		public static GameData GameData => Instance.gameData;
		public static ItemData[] Items => Instance.items;
		
		[SerializeField] private GameData gameData;
		private ItemData[] items;

		protected override void Awake()
		{
			base.Awake();
			items = Resources.FindObjectsOfTypeAll<ItemData>();
		}
	}
}