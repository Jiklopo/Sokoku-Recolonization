using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class LevelCompletedScreen: UIElementSingleton<LevelCompletedScreen>
	{
		[SerializeField] private Button retryButton;
		[SerializeField] private Button mainMenuButton;
		[SerializeField] private Button quitButton;

		protected override void OnAwake()
		{
			base.OnAwake();
			var currentScene = SceneManager.GetActiveScene();
			retryButton.onClick.AddListener(() => SceneManager.LoadScene(currentScene.buildIndex));
			mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(0));
			quitButton.onClick.AddListener(Application.Quit);
			GameBus.OnGameCompleted += Show;
		}

		private void OnDestroy()
		{
			GameBus.OnGameCompleted -= Show;
		}
		
		protected override void OnShown()
		{
			Cursor.visible = true;
			Player.Player.IsControllable = false;
		}

		protected override void OnClosed()
		{
			Cursor.visible = false;
			Player.Player.IsControllable = true;
		}
	}
}