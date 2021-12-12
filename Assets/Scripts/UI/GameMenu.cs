using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class GameMenu : UIElementSingleton<GameMenu>
	{
		[SerializeField] private Button resumeButton;
		[SerializeField] private Button restartButton;
		[SerializeField] private Button menuButton;
		[SerializeField] private Button quitButton;

		protected override void OnAwake()
		{
			base.OnAwake();
			resumeButton.onClick.AddListener(CloseInstance);
			restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
			menuButton.onClick.AddListener(() => SceneManager.LoadScene(0));
			quitButton.onClick.AddListener(Application.Quit);
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