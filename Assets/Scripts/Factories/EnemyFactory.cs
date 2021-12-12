using Enemies;
using InventorySystem;

namespace Factories
{
	public class EnemyFactory: Factory<Enemy, EnemyFactory>
	{
		protected override Enemy InstantiateItem(int selectedItemIndex)
		{
			return Instantiate(objectsList[selectedItemIndex]);
		}
	}
}