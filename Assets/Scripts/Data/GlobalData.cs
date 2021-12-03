using UnityEngine;
using Utilities;

namespace Data
{
	public class GlobalData : Singleton<GlobalData>
	{
		public static GameData GameData => Instance.gameData;
		
		[SerializeField] private GameData gameData;
	}
}