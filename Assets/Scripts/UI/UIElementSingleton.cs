namespace UI
{
	public abstract class UIElementSingleton<T>: UIElement where T:UIElement
	{
		public static T Instance { get; protected set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			if(Instance != null)
				Destroy(this);

			Instance = this as T;
		}

		public static void ShowInstance() => Instance.Show();

		public static void CloseInstance() => Instance.Close();

		public static void ToggleInstance() => Instance.Toggle();
	}
}