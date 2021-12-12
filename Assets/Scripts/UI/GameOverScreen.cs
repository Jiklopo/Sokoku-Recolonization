using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class GameOverScreen: UIElementSingleton<GameOverScreen>
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
			GameBus.OnGameOver += Show;
		}

		private void OnDestroy()
		{
			GameBus.OnGameOver -= Show;
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