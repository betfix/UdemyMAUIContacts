using UdemyMAUIContacts.Models;
using Contact = UdemyMAUIContacts.Models.Contact;

namespace UdemyMAUIContacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	public string? ContactId
	{
		set
		{
			var contact = ContactRepository.GetContactById(int.Parse(value!));
			if (contact == null)
				return;
			ContactCtrl.ContactId = contact.ContactId;
			ContactCtrl.Name = contact.Name;
			ContactCtrl.Phone = contact.Phone;
			ContactCtrl.Email = contact.Email;
			ContactCtrl.Address = contact.Address;
		} 
	}

	public EditContactPage()
	{
		InitializeComponent();
	}


	private void SaveButton_OnClicked(object sender, EventArgs e)
	{
		var contact = new Contact()
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