using System;
using System.Collections;
using Data;
using Factories;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Enemies
{
	[RequireComponent(typeof(NavMeshAgent))]
	[RequireComponent(typeof(Animator))]
	public abstract class Enemy : MonoBehaviour, IEntity, IFactoryProduct
	{
		[Header("Stats")]
		[SerializeField] protected float baseHealth;
		[SerializeField] protected float baseDamage;
		[SerializeField] protected float attackCooldown;
		[SerializeField] protected float speed;
		[SerializeField] protected int spawnChanceWeight;
		[SerializeField] protected float itemDropChance = 0.1f;

		[Header("Animation Data")]
		[SerializeField] protected AnimationData attackAnimationData;
		[SerializeField] protected AnimationData movementAnimationData;
		[SerializeField] protected AnimationData deathAnimationData;

		public float Health => health;
		public int DropChanceWeight => spawnChanceWeight;
		public bool IsDead { get; protected set; }

		protected float health;
		protected float damage;
		protected NavMeshAgent agent;
		protected Animator animator;
		protected Player.Player player;

		protected virtual void Awake()
		{
			// TODO: use global difficulty
			health = baseHealth;
			damage = baseDamage;
			
			agent = GetComponent<NavMeshAgent>();
			animator = GetComponent<Animator>();
			player = FindObjectOfType<Player.Player>();
		}

		public void ReceiveDamage(float amount)
		{
			CustomLogger.Log($"{name} received {amount} damage!", this);
			health -= amount;
			if (health <= 0)
				Die();
		}

		public void ReceiveHeal(float amount)
		{
			health += amount;
			health = Mathf.Min(health, baseHealth);
		}

		protected virtual void Die()
		{
			if(IsDead)
				return;

			IsDead = true;
			agent.enabled = false;
			CustomLogger.Log($"{name} died!", this);
			animator.SetTrigger(deathAnimationData.TriggerHash);
			var position = transform.position;
			ResourceFactory.Instance.GetRandomObject().transform.position = position;
			var item = ItemFactory.Instance.SpawnRandomItem(itemDropChance);
			if (item != null)
				item.transform.position = position;
			StartCoroutine(
				DelayActionRoutine(deathAnimationData.Duration, () => Destroy(gameObject))
			);
		}

		protected IEnumerator DelayActionRoutine(float delay, Action action)
		{
			yield return new WaitForSeconds(delay);
			action.Invoke();
		}

		protected abstract void Attack();
	}
}