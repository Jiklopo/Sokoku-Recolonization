using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemies
{
	public class MeleeEnemy: Enemy
	{
		[SerializeField] private float destinationUpdateInterval = 5f;
		protected override void Awake()
		{
			base.Awake();
			agent = GetComponent<NavMeshAgent>();
		}

		private void Start()
		{
			StartCoroutine(UpdateDestinationRoutine());
		}

		IEnumerator UpdateDestinationRoutine()
		{
			var step = new WaitForSeconds(destinationUpdateInterval);
			while (true)
			{
				agent.destination = Player.Player.Instance.transform.position;
				yield return step;
			}
		}
	}
}