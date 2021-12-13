using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class PlayerResourcesUI: UIElement
	{
		[SerializeField] private TextMeshProUGUI percentText;
		[SerializeField] private Image resourceBar;
		protected override void OnAwake()
		{
			PlayerResources.OnResourcesChanged += UpdateUI;
		}

		private void OnDestroy()
		{
			PlayerResources.OnResourcesChanged -= UpdateUI;
		}

		private void UpdateUI(float hp)
		{
			percentText.SetText($"{hp:P}");
			resourceBar.fillAmount = hp;

			if (hp >= 1)
				Close();
		}
	}
}