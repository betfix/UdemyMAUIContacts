namespace Contacts.MAUI.Views_MVVM.Controls;

public partial class ContactControl_MVVM : ContentView
{
	public ContactControl_MVVM()
	{
		InitializeComponent();
	}

		protected override void OnBindingContextChanged()
		{
				base.OnBindingContextChanged();
		}
}