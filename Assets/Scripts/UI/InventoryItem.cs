using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InventoryItem : MonoBehaviour
	{
		[SerializeField] private Image itemImage;
		[SerializeField] private TextMeshProUGUI countText;
		private ItemData data;

		public void SetData(ItemData itemData, int amount)
		{
			itemImage.sprite = itemData.icon;
			countText.SetText(amount.ToString());
		}

		public void Clear()
		{
			itemImage.sprite = null;
			countText.SetText("");
		}
	}
}