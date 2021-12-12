using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class SettingsScreen: UIElementSingleton<SettingsScreen>
	{
		[SerializeField] private TMP_Dropdown resolutionDropdown;
		[SerializeField] private TMP_Dropdown graphicsDropdown;
		[SerializeField] private Slider volumeSlider;
		[SerializeField] private Button backButton;
		[SerializeField] private Button acceptButton;

		private List<Resolution> resolutions;

		protected override void OnAwake()
		{
			base.OnAwake();
			resolutions = Screen.resolutions.ToList();
			resolutionDropdown.ClearOptions();
			resolutionDropdown.AddOptions(resolutions.Select(res => res.ToString()).ToList());
			resolutionDropdown.value = resolutions.IndexOf(Screen.currentResolution);
			resolutionDropdown.onValueChanged.AddListener(i =>
			{
				var r = resolutions[i];
				Screen.SetResolution(r.width, r.height, true, r.refreshRate);
			});
			
			graphicsDropdown.ClearOptions();
			graphicsDropdown.AddOptions(new List<string> {"High"});
			
			backButton.onClick.AddListener(() => Close());
			acceptButton.onClick.AddListener(() => Close());
		}
	}
}