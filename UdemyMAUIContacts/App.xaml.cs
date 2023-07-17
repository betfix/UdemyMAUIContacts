namespace UdemyMAUIContacts;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = base.CreateWindow(activationState);

		if ( DeviceInfo.Platform == DevicePlatform.WinUI )
		{
			const int newWidth = 400;
			const int newHeight = 600;
        
			window.Width = newWidth;
			window.Height = newHeight;
		}

		return window;
	}
}