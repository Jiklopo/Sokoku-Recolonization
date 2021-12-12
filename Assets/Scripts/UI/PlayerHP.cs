using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class PlayerHP: UIElement
	{
		[SerializeField] private TextMeshProUGUI hpText;
		[SerializeField] private Image hpBar;
		protected override void OnAwake()
		{
			Player.Player.OnPlayerHPUpdated += UpdateUI;
		}

		private void OnDestroy()
		{
			Player.Player.OnPlayerHPUpdated -= UpdateUI;

		}

		private void UpdateUI(float hp)
		{
			hpText.SetText($"{hp:P}");
			hpBar.fillAmount = hp;
		}
	}
}