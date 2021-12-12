using Interfaces;
using Player;
using UnityEngine;

namespace Objects
{
	public class Resource : MonoBehaviour, IFactoryProduct, ICollisionTarget
	{
		public int DropChanceWeight => dropChanceWeight;
		
		[SerializeField] private int dropChanceWeight;
		[SerializeField] protected int resourceAmount;
		private bool isUsed;

		public void OnCollision(GameObject other)
		{
			if (isUsed)
				return;

			isUsed = true;
			other.GetComponent<PlayerResources>()?.AddResources(resourceAmount);
			Destroy(gameObject);
		}
	}
}