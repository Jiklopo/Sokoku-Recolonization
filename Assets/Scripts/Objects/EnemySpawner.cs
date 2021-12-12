using System;
using System.Collections;
using Factories;
using UnityEngine;

namespace Objects
{
	public class EnemySpawner: MonoBehaviour
	{
		[SerializeField] private float spawnInterval;

		private void OnEnable()
		{
			StartCoroutine(SpawnRoutine());
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private IEnumerator SpawnRoutine()
		{
			var interval = new WaitForSeconds(spawnInterval);
			
			while (true)
			{
				yield return interval;
				if(!EnemyFactory.Instance.IsInitialized)
					continue;

				EnemyFactory.Instance.GetRandomObject().transform.position = transform.position;
			}
		}
	}
}