using System;
using System.Collections;
using UnityEngine;

namespace Enemies
{
	public class MeleeEnemy: Enemy
	{
		[SerializeField] private float destinationUpdateInterval = 5f;
		[SerializeField] private float attackRange;

		private Coroutine updateDestinationRoutine;
		private EnemyHitCollider[] hitColliders;
		private bool isAttacking;

		protected override void Awake()
		{
			base.Awake();
			hitColliders = GetComponentsInChildren<EnemyHitCollider>();
		}

		private void OnEnable()
		{
			updateDestinationRoutine = StartCoroutine(UpdateDestinationRoutine());
			foreach (var enemyHitCollider in hitColliders)
				enemyHitCollider.Init(damage, attackCooldown);
			StartWalking();
		}

		private void OnDisable()
		{
			StopCoroutine(updateDestinationRoutine);
		}

		private void Update()
		{
			if(!isAttacking && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
				Attack();
		}

		protected override void Attack()
		{
			isAttacking = true;
			agent.speed = 0;
			foreach (var enemyHitCollider in hitColliders)
				enemyHitCollider.gameObject.SetActive(true);
			animator.SetTrigger(attackAnimationData.TriggerHash);
			StartCoroutine(
				DelayActionRoutine(attackAnimationData.Duration, StartWalking)
			);
		}

		IEnumerator UpdateDestinationRoutine()
		{
			var step = new WaitForSeconds(destinationUpdateInterval);
			while (true)
			{
				agent.destination = player.transform.position;
				yield return step;
			}
		}

		private void StartWalking()
		{
			isAttacking = false;
			agent.speed = speed;
			animator.SetTrigger(movementAnimationData.TriggerHash);
			foreach (var enemyHitCollider in hitColliders)
				enemyHitCollider.gameObject.SetActive(false);
		}
	}
}