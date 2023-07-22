using Contacts.MAUI.ViewModels;

namespace Contacts.MAUI.Views_MVVM;

[QueryProperty(nameof(ContactId), "ContactId")]
public partial class EditContact_MVVM_Page : ContentPage
{
	private readonly ContactViewModel _contactViewModel;

	public string ContactId
	{
		set
		{
			if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int contactId))
			{
				LoadContact(contactId);
			}
		}
	}

	private async void LoadContact(int contactId)
	{
		await _contactViewModel.LoadContactAsync(contactId);
		if (_contactViewModel.Contact is null)
		{
			await Shell.Current.GoToAsync(nameof(Contacts_MVVM_Page));
		}
	}

	public EditContact_MVVM_Page(ContactViewModel contactViewModel)
	{
		InitializeComponent();
		_contactViewModel = contactViewModel;
		_contactViewModel.IsAddNewVisible = false;
		_contactViewModel.IsUpdateVisible = true;
		BindingContext = _contactViewModel;
	}
}