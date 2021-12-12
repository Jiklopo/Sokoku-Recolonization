using Data;
using DG.Tweening;
using Factories;
using Interfaces;
using UnityEngine;

namespace Objects
{
	public class Chest : MonoBehaviour, IInteractable
	{
		[SerializeField] private Vector3 itemOffset;
		[SerializeField] private AnimationData animationData;
		[SerializeField] private Animator animator;
		[SerializeField] private float dropForce;

		private bool isUsed;

		public void OnInteract()
		{
			if (isUsed)
				return;

			isUsed = true;
			animator.SetTrigger(animationData.TriggerHash);
			DOVirtual.DelayedCall(animationData.Duration, () => isUsed = SpawnItem());
		}

		private bool SpawnItem()
		{
			var item = ItemFactory.Instance.SpawnRandomItem(1, transform);
			if (item == null)
				return false;
			
			item.transform.Translate(itemOffset);
			var force = (transform.forward + Vector3.up) * dropForce;
			item.GetComponent<Rigidbody>()?.AddForce(force, ForceMode.Impulse);
			return true;
		}
	}
}