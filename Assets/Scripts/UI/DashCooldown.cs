using System;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class DashCooldown: UIElement
	{
		[SerializeField] private Image cooldownImage;
		
		protected override void OnAwake()
		{
			base.OnAwake();
			PlayerController.OnDash += UpdateUI;
			cooldownImage.fillAmount = 0;
		}

		private void OnDestroy()
		{
			PlayerController.OnDash -= UpdateUI;
		}

		private void UpdateUI(float cooldownDuration)
		{
			cooldownImage.fillAmount = 1;
			cooldownImage.DOFillAmount(0, cooldownDuration);
		}
	}
}