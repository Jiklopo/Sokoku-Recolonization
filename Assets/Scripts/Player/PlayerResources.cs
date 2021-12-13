using System;
using UnityEngine;
using Utilities;

namespace Player
{
	[RequireComponent(typeof(Player))]
	public class PlayerResources : MonoBehaviour
	{
		public static Action<float> OnResourcesChanged;

		[SerializeField] private int resourcesRequired;
		private float resources;

		public float Resources
		{
			get => resources;
			private set
			{
				resources = value;
				OnResourcesChanged?.Invoke(resources / resourcesRequired);
			}
		}


		public void AddResources(int amount)
		{
			Resources += amount;
			CustomLogger.Log($"Added {amount} resources. {resources}/{resourcesRequired}");
		}
	}
}