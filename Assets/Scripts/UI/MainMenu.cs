using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class MainMenu : UIElementSingleton<MainMenu>
	{
		[SerializeField] private Button playButton;
		[SerializeField] private Button exitButton;

		protected override void OnAwake()
		{
			base.OnAwake();
			playButton.onClick.AddListener(StartFirstLevel);
			exitButton.onClick.AddListener(Quit);
		}

		private void StartFirstLevel()
		{
			SceneManager.LoadScene(1);
		}

		private void Quit()
		{
			Application.Quit();
		}
	}
}