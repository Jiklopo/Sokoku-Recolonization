using DG.Tweening;
using UnityEngine;

namespace Enemies
{
	[RequireComponent(typeof(Collider))]
	public class EnemyHitCollider: MonoBehaviour, ICollisionTarget
	{
		private float damage;
		private float damageCooldown;
		private bool canAttack = true;
		
		public void OnCollision(GameObject other)
		{
			if (!canAttack)
				return;
			
			var player = other.GetComponent<Player.Player>();
			player.ReceiveDamage(damage);
			canAttack = false;
			DOVirtual.DelayedCall(damageCooldown, () => canAttack = true);
		}

		public void Init(float damage, float damageCooldown)
		{
			this.damage = damage;
			this.damageCooldown = damageCooldown;
		}
	}
}