using Contacts.UseCases.Interfaces;
using Contact = Contacts.Core.ContactEntity;

namespace Contacts.MAUI.Views;

public partial class AddContactPage : ContentPage
{
	private readonly IAddContactUseCase _addContactUseCase;


	public AddContactPage(IAddContactUseCase addContactUseCase)
	{
		_addContactUseCase = addContactUseCase;
		InitializeComponent();
	}


	private async void ContactCtrl_OnSave(object? sender, EventArgs e)
	{
		await _addContactUseCase.ExecuteAsync(new Contact
		{
			Name = ContactCtrl.Name,
			Phone = ContactCtrl.Phone,
			Email = ContactCtrl.Email,
			Address = ContactCtrl.Address,
		});
		await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
	}


	private void ContactCtrl_OnCancel(object? sender, EventArgs e)
	{
		Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
	}


	private void ContactCtrl_OnError(object? sender, string e)
	{
		DisplayAlert("Error", e, "OK");
	}
}