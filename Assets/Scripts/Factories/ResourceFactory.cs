using InventorySystem;
using Objects;
using UnityEngine;

namespace Factories
{
	public class ResourceFactory: Factory<Resource, ResourceFactory>
	{
		protected override Resource InstantiateItem(int selectedItemIndex)
		{
			var resource =  base.InstantiateItem(selectedItemIndex);
			var rb = resource.GetComponent<Rigidbody>();
			var randomVector = Vector3.one * Random.Range(1f, 3f);
			rb.AddForce(randomVector, ForceMode.Impulse);
			return resource;
		}
	}
}