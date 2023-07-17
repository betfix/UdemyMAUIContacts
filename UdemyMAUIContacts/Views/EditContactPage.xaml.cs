using Contacts.UseCases.Interfaces;
using UdemyMAUIContacts.Models;
using Contact = Contacts.Core.Contact;

namespace UdemyMAUIContacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private readonly IViewContactUseCase _viewContactUseCase;


	public EditContactPage(IViewContactUseCase viewContactUseCase)
	{
		_viewContactUseCase = viewContactUseCase;
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

	private void SaveButton_OnClicked(object sender, EventArgs e)
	{
		var contact = new UdemyMAUIContacts.Models.Contact()
		{
			ContactId = ContactCtrl.ContactId,
			Name = ContactCtrl.Name,
			Phone = ContactCtrl.Phone,
			Email = ContactCtrl.Email,
			Address = ContactCtrl.Address,
		};

		ContactRepository.UpdateContact(contact.ContactId, contact);
		
		Shell.Current.GoToAsync("..");
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