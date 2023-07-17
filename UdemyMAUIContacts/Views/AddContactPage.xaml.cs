using UdemyMAUIContacts.Models;
using Contact = UdemyMAUIContacts.Models.Contact;

namespace UdemyMAUIContacts.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}


	private void ContactCtrl_OnSave(object? sender, EventArgs e)
	{
		ContactRepository.AddContact(new Contact
		{
			Name = ContactCtrl.Name,
			Phone = ContactCtrl.Phone,
			Email = ContactCtrl.Email,
			Address = ContactCtrl.Address,
		});
		Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
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