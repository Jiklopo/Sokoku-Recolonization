using UnityEngine;

namespace Data
{
	[CreateAssetMenu(fileName = "Game Data", menuName = "Scriptable Objects/Game Data", order = 0)]
	public class GameData : ScriptableObject
	{
		public ItemData[] itemsInformation;
	}
}