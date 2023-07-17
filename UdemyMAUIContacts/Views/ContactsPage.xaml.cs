using System.Collections.ObjectModel;
using UdemyMAUIContacts.Models;
using Contact = UdemyMAUIContacts.Models.Contact;

namespace UdemyMAUIContacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		LoadContacts();
	}

	private void LoadContacts()
	{
		ContactsList.ItemsSource = new ObservableCollection<Contact>(ContactRepository.Contacts);
		Search.Text = "";
	}

	private void ContactsList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if ( e.SelectedItem == null )
			return;
	}

	private void ContactsList_OnItemTapped(object sender, ItemTappedEventArgs e)
	{
		if ( e.Item is not Contact contact )
			return;
		Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.ContactId}");
	}

	private void AddBtn_OnClicked(object? sender, EventArgs e)
	{
		Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
	}

	private void Item_Delete(object? sender, EventArgs e)
	{
		var menuItem = sender as MenuItem;
		if ( menuItem?.CommandParameter is not Contact contact )
			return;
		ContactRepository.DeleteContact(contact.ContactId);
		LoadContacts();
	}

	private void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		if ( sender is not SearchBar searchBar )
			return;
		ContactsList.ItemsSource = new ObservableCollection<Contact>(
			ContactRepository.SearchContacts(searchBar.Text));
	}
}