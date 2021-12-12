using System;
using Events;
using Player;
using UnityEngine;

namespace Objects
{
	public class Portal: MonoBehaviour, ICollisionTarget
	{
		[SerializeField] private ParticleSystem particleSystem;
		
		private bool isActivated;
		private bool isUsed;

		private void Awake()
		{
			PlayerResources.OnResourcesChanged += OnResourcesChanged;
		}

		private void OnResourcesChanged(float fillAmount)
		{
			isActivated = fillAmount >= 1;

			if (isActivated)
				particleSystem.Play();
		}

		public void OnCollision(GameObject other)
		{
			if (!isActivated || isUsed)
				return;
			
			GameBus.OnGameCompleted.Invoke();
			isUsed = true;
		}
	}
}