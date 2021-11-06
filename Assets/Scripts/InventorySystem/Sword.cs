namespace InventorySystem
{
	public class Sword: Item
	{
		public override bool IsUsable => true;
		public override int MaxStack => 1;
		public override string Name => "Sword";
	}
}