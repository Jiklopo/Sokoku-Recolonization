using Interfaces;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Enemies
{
	[RequireComponent(typeof(NavMeshAgent))]
	public abstract class Enemy : MonoBehaviour, IEntity, IFactoryProduct
	{
		[SerializeField] protected float maxHealth;
		[SerializeField] protected float damage;
		[SerializeField] protected float speed;
		[SerializeField] protected int dropChanceWeight;

		protected float health;
		public float Health => health;
		public int DropChanceWeight => dropChanceWeight;

		protected NavMeshAgent agent;


		protected virtual void Awake()
		{
			health = maxHealth;
			agent = GetComponent<NavMeshAgent>();
		}

		public void ReceiveDamage(float amount)
		{
			health -= amount;
			if (health <= 0)
				Die();
		}

		public void ReceiveHeal(float amount)
		{
			health += amount;
			health = Mathf.Min(health, maxHealth);
		}

		protected virtual void Die()
		{
			CustomLogger.Log($"{name} died!", this);
			Destroy(gameObject);
		}
	}
}