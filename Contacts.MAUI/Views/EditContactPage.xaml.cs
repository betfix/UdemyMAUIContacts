using Contacts.UseCases.Interfaces;
using Contact=Contacts.Core.ContactEntity;

namespace Contacts.MAUI.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private readonly IViewContactUseCase _viewContactUseCase;
	private readonly IEditContactUseCase _editContactUseCase;


	public EditContactPage(IViewContactUseCase viewContactUseCase, IEditContactUseCase editContactUseCase)
	{
		_viewContactUseCase = viewContactUseCase;
		_editContactUseCase = editContactUseCase;
		InitializeComponent();
	}

	public string ContactId
	{
		set
		{
			var contact = _viewContactUseCase.ExecuteAsync(int.Parse(value!))?
				.GetAwaiter()
				.GetResult(); //TODO: Fix this async?


			if (contact == null)
				return;

			ContactCtrl.ContactId = contact.ContactId;
			ContactCtrl.Name = contact.Name;
			ContactCtrl.Phone = contact.Phone;
			ContactCtrl.Email = contact.Email;
			ContactCtrl.Address = contact.Address;
		} 
	}

	private async void SaveButton_OnClicked(object sender, EventArgs e)
	{
		var contact = new Contact()
		{
			ContactId = ContactCtrl.ContactId,
			Name = ContactCtrl.Name,
			Phone = ContactCtrl.Phone,
			Email = ContactCtrl.Email,
			Address = ContactCtrl.Address,
		};

		await _editContactUseCase.ExecuteAsync(contact.ContactId, contact);
		
		await Shell.Current.GoToAsync("..");
	}


	private void CancelButton_OnClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}


	private void ContactCtrl_OnError(object? sender, string message)
	{
		DisplayAlert("Error", message, "OK");
	}
}