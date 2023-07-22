using Contacts.MAUI.ViewModels;

namespace Contacts.MAUI.Views_MVVM;

public partial class AddContact_MVVM_Page : ContentPage
{
	private readonly ContactViewModel _contactViewModel;

	public AddContact_MVVM_Page(ContactViewModel contactViewModel)
	{
		InitializeComponent();
		_contactViewModel = contactViewModel;
		_contactViewModel.IsAddNewVisible = true;
		_contactViewModel.IsUpdateVisible = false;
		BindingContext = _contactViewModel;
	}
}