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

		public InventoryItem SetData(ItemData itemData, int amount)
		{
			itemImage.sprite = itemData.icon;
			countText.SetText(amount.ToString());
			return this;
		}

		public InventoryItem Clear()
		{
			itemImage.sprite = null;
			countText.SetText("");
			return this;
		}
	}
}