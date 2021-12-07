namespace Interfaces
{
	public interface IEntity
	{
		public float Health { get; }

		public void ReceiveDamage(float amount);

		public void ReceiveHeal(float amount);
	}
}